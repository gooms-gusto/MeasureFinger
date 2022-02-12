using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using EncrytionHash;
using log4net;
namespace MeasureFinger
{
    public partial class FormMainMenu : Form
    {
        private Proxy _proxy = new Proxy();
        private NewData _ctrl_newdata = new NewData();
        private int _jumlah_data = 0;
        private ReportDocument _doc = new ReportDocument();
        private EncrytionHash.Kunci _kunci = new Kunci();
        public FormMainMenu()
        {
           
            try
            {
                
                    DAL.Mpath.SetPathStartup = Environment.CurrentDirectory;
                    InitializeComponent();
            
                    this.WindowState = FormWindowState.Maximized;
                    ModuleStatic.SetPathUtama = Environment.CurrentDirectory;
                    _doc.Load(ModuleStatic.SetPathUtama + "\\MyReport.rpt");


            if (_proxy._GetHardware()._GetValue().Trim() == _proxy._GetLic()._GetLisensi())
            {
                _ReloadDataPasien("","");
                this.Text = "Sofware ini telah dilisensi [life time] oleh " + _proxy._GetLic()._GetCompany().ToUpper();
                FORM_LOGIN _formLogin = new FORM_LOGIN();
                _formLogin.ShowDialog();
            }
            else
            {
                //_mnu_utama_pasien.Enabled = false;
                //_mnu_utama_sidik.Enabled = false;
                //this.Text = "SOFTWARE ANALISA SIDIK JARI  **** BELUM DI LISENSI *****";
                FORM_LISENSI _formLisensi = new FORM_LISENSI();
                _formLisensi.Closing += new CancelEventHandler(_formLisensi_Closing);
                _formLisensi.ShowDialog();
                if (!ModuleStatic.GetSetTrial)
                {
                    _ReloadDataPasien("","");
                    this.Text = "Sofware ini telah dilisensi [life time] oleh " +
                                _proxy._GetLic()._GetCompany().ToUpper();
                }
                else
                {
                    _ReloadDataPasien("","");
                    this.Text = "Software ini belum dilisensi, status masih TRIAL";
                }
            }

            _ReloadDataPasien("","");
             
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        void _formLisensi_Closing(object sender, CancelEventArgs e)
        {
            if (ModuleStatic.GetSetTrial)
                return;

            if (_proxy._GetHardware()._GetValue().Trim() != _proxy._GetLic()._GetLisensi())
            {
                Application.Exit();
            }
        }

        private void _ReloadDataPasien(string value1,string value2)
        {
           

            DataTable _dataTable=null;

            if (string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
                _dataTable = _proxy._GetPasien()._SelectPasien("", "");

            if (!string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
                _dataTable = _proxy._GetPasien()._SelectPasien(value1, "");

            if (string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2))
                _dataTable = _proxy._GetPasien()._SelectPasien("", value2);

            _DgPasien.DataSource = _dataTable;
          
            _DgPasien.Cols[2].StyleDisplay.BackColor = Color.DarkOrange;
            _DgPasien.Cols[4].Caption = "Umur(Thn)";
            _jumlah_data = _dataTable.Rows.Count;
            for (int putar=5;putar <16;putar++)
            {
                _DgPasien.Cols[putar].Visible = false;
            }
            _DgPasien.AutoSizeCols();
        }



        void _formEntryPasien__EventSimpanSukses()
        {
            _ReloadDataPasien("","");
        }

        private void _BtnCari_Click(object sender, EventArgs e)
        {
           _ReloadDataPasien("", _TxtValue.Text);
            
        }

        private void _TxtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                DataTable _dataTable = _proxy._GetPasien()._SelectPasien("", _TxtValue.Text);
                _jumlah_data = _dataTable.Rows.Count;
                _ReloadDataPasien("", _TxtValue.Text);
            }
        }

       

        private void _BtnHapusPasien_Click(object sender, EventArgs e)
        {
            string _ID = null;
            int current = (_DgPasien.Row > 0) ? _DgPasien.Rows[_DgPasien.Row].DataIndex : -1;
            current++;
            if (_jumlah_data > 0)
            {
                _ID = _DgPasien.Rows[current][1].ToString().Trim();
            }
            else
            {
                return;
            }

            DialogResult _dialogResult = MessageBox.Show("Apakah andah yakin untuk menghapus data pasien?", "Konfirmasi",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button2);


            if (_dialogResult==DialogResult.Yes)
            {
                _proxy._GetPasien()._DeletePasien(_ID);
                _ReloadDataPasien("","");
            }
        }

        private void _BtnTambahPasien_Click(object sender, EventArgs e)
        {
            FORM_ENTRY_PASIEN _formEntryPasien = new FORM_ENTRY_PASIEN();
            _formEntryPasien._EventSimpanSukses += new _SimpanSukses(_formEntryPasien__EventSimpanSukses);
            _formEntryPasien.ShowDialog();
        }

        private void _BtnUbahPasien_Click(object sender, EventArgs e)
        {
            string _ID = null;
            int current = (_DgPasien.Row > 0) ? _DgPasien.Rows[_DgPasien.Row].DataIndex : -1;
            current++;
            if (_jumlah_data > 0)
            {
                _ID = _DgPasien.Rows[current][1].ToString().Trim();
            }
            else
            {
                return;
            }
            FORM_ENTRY_PASIEN _formEntryPasien = new FORM_ENTRY_PASIEN(_ID);
            _formEntryPasien._EventSimpanSukses += new _SimpanSukses(_formEntryPasien__EventSimpanSukses);
            _formEntryPasien.ShowDialog();
        }

        private void _BtnHitungJarak_Click(object sender, EventArgs e)
        {
            string _ID = null;
            int current = (_DgPasien.Row > 0) ? _DgPasien.Rows[_DgPasien.Row].DataIndex : -1;
            current++;
            if (_jumlah_data > 0)
            {
                _ID = _DgPasien.Rows[current][1].ToString().Trim();
            }
            else
            {
                return;
            }

            FORM_UKUR _formUkur = new FORM_UKUR(_ID);
            _formUkur.ShowDialog();
        }

        private void _BtnHitungProsentase_Click(object sender, EventArgs e)
        {
          

            string _ID = null;
            int current = (_DgPasien.Row > 0) ? _DgPasien.Rows[_DgPasien.Row].DataIndex : -1;
            current++;
            if (_jumlah_data > 0)
            {
                _ID = _DgPasien.Rows[current][1].ToString().Trim();
            }
            else
            {
                return;
            }

            if (!_proxy._GetPasien()._ValidasiUkur(_ID))
            {
                MessageBox.Show("Pengukuran belum lengkap dari ke 5 jari, silakan lengkapi lebih dulu!",
                                "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           //FORM_HASIL_ANALISA _formHasilAnalisa=new FORM_HASIL_ANALISA(_ID);
           // _formHasilAnalisa.ShowDialog();
            FORM_OUTPUTANALISA _formOutputanalisa=new FORM_OUTPUTANALISA(_ID);
            _formOutputanalisa.ShowDialog();
        }

        private void _Btn_lisensi_Click(object sender, EventArgs e)
        {
            if (ModuleStatic.GetSetTrial)
            {
                MessageBox.Show("Software ini masih trial!, silakan lakukan registrasi!", "Warning system",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (_proxy._GetHardware()._GetValue().Trim() == _proxy._GetLic()._GetLisensi())
            {
                FORM_LEGAL _formLegal = new FORM_LEGAL();
                _formLegal._event_lisensi_hapus += new _lisensi_hapus(_formLegal__event_lisensi_hapus);
                _formLegal.ShowDialog();
            }
            else
            {
                FORM_LISENSI _formLisensi = new FORM_LISENSI();
                _formLisensi.ShowDialog();
            }
           
        }

        void _formLegal__event_lisensi_hapus()
        {
            _mnu_utama_pasien.Enabled = false;
            _mnu_utama_sidik.Enabled = false;
            this.Text = "Software Analisa Sidik Jari  **** BELUM DI LISENSI *****";
        }

        void _formLisensi__event_sukses_registrasi()
        {
            _mnu_utama_pasien.Enabled =true;
            _mnu_utama_sidik.Enabled = true;
            this.Text ="Software ini telah di lisensi oleh " + _proxy._GetLic()._GetCompany();
            _ReloadDataPasien("","");
        }

        private void _Mnu_Ubah_Login_Click(object sender, EventArgs e)
        {
            FORM_UBAH_PASSWORD _formUbahPassword=new FORM_UBAH_PASSWORD();
            _formUbahPassword.ShowDialog();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _txtstatustimer.Text = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss WIB");
        }





    }
}