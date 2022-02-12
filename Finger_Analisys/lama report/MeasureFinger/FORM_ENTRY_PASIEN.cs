using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.IO;

public delegate void _SimpanSukses();
namespace MeasureFinger
{
    public partial class FORM_ENTRY_PASIEN : Form
    {
        private Proxy _proxy = new Proxy();
        private string _idpasien;
        public event _SimpanSukses _EventSimpanSukses;
        public bool _modeupdate = false;
        private string _kodeupdatepasien;
        public FORM_ENTRY_PASIEN()
        {
            InitializeComponent();
          
           
        }
        public FORM_ENTRY_PASIEN(string ParamKodePasien)
        {
            InitializeComponent();
            _modeupdate = true;
            _kodeupdatepasien = ParamKodePasien;
            _fill_pasien(ParamKodePasien);

        }

        void _fill_pasien(string KodePasien)
        {
            try
            {
                DataTable _Dt = _proxy._GetPasien()._SelectPasien(KodePasien, "");
                _txtnamapasien.Text = _Dt.Rows[0]["NAMA_PASIEN"].ToString();
                 DateTime MyDateTime = new DateTime();
                 MyDateTime = Convert.ToDateTime(_Dt.Rows[0]["TANGGAL_ANALISA"].ToString());
                _txttanggalanalisa.Value = MyDateTime;
                _txtusia.Text = _Dt.Rows[0]["USIA"].ToString();
                _l1.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["L1"].ToString();
                _l2.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["L2"].ToString();
                _l3.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["L3"].ToString();
                _l4.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["L4"].ToString();
                _l5.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["L5"].ToString();
                _r1.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["R1"].ToString();
                _r2.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["R2"].ToString();
                _r3.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["R3"].ToString();
                _r4.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["R4"].ToString();
                _r5.Text = ModuleStatic.GetPathGambar + KodePasien + "\\" + _Dt.Rows[0]["R5"].ToString();
            }
           
            catch (Exception)
            {

            }
        }


        bool _simpan_gambar(string _path_source,string id_pasien,string posisijari)
        {
          


            try
            {
                ModuleStatic.SetFolderID(id_pasien);
                if (_path_source!= ModuleStatic.GetPathGambar + id_pasien + "\\" + posisijari + ".jpg")
                {

                    File.Copy(_path_source, ModuleStatic.GetPathGambar + id_pasien + "\\" + posisijari + ".jpg",true);
                    //if (File.Exists(ModuleStatic.GetPathGambar + id_pasien + "\\" + posisijari + ".jpg"))
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }


         void _clear_entry()
         {
             foreach(Control _cID in _groupidentitas.Controls)
             {
                if ( _cID.Tag=="idpasien")
                 _cID.Text = string.Empty;
             }

             foreach(Control _cSIDIK in _groupsidik.Controls)
             {
                 if (_cSIDIK.Tag == "sidik")
                 {
                     _cSIDIK.Text = string.Empty;
                     _cSIDIK.Text = "";
                 }
             }
             _txtnamapasien.Select();
         }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            Button _btnbrowse = (Button) (sender);
            string _name = _btnbrowse.Name;
            _OFD.Title = _btnbrowse.Name;
            _OFD.Filter = "JPEG files |*.jpg;*.jpeg";
            _OFD.ShowDialog();
           
            switch(_name)
            {
                case "l1":
                    _l1.Text = _OFD.FileName;
                    break;
                case "l2":
                    _l2.Text = _OFD.FileName;
                    break;
                case "l3":
                    _l3.Text = _OFD.FileName;
                    break;
                case "l4":
                    _l4.Text = _OFD.FileName;
                    break;
                case "l5":
                    _l5.Text = _OFD.FileName;
                    break;
                case "r1":
                    _r1.Text = _OFD.FileName;
                    break;
                case "r2":
                    _r2.Text = _OFD.FileName;
                    break;
                case "r3":
                    _r3.Text = _OFD.FileName;
                    break;
                case "r4":
                    _r4.Text = _OFD.FileName;
                    break;
                case "r5":
                    _r5.Text = _OFD.FileName;
                    break;
            }

        }

        private void _btnsimpan_Click(object sender, EventArgs e)
        {

            string[] _filenamegambar = new string[10];
            DialogResult _dialogResult;


            if (string.IsNullOrEmpty(_txtnamapasien.Text) || string.IsNullOrEmpty( _txtusia.Text))
            {
                MessageBox.Show("Identitas pasien masih ada yang kosong!", "Informasi", MessageBoxButtons.OK,
                                   MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

                return;
            }

            foreach (Control _control in _groupsidik.Controls)
            {
                if (string.IsNullOrEmpty(_control.Text) && _control.Tag == "sidik")
                {
                    MessageBox.Show("Gambar sidik jari harus terisi semua!", "Informasi", MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    
                    return;
                }
                if (!File.Exists(_control.Text) && _control.Tag == "sidik")
                {
                    MessageBox.Show("Gambar sidik tidak ada!", "Informasi", MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    return;
                }
            }

            


            //simpan fisik gambar
            int _index = 0;
          
            foreach(Control _IMG in _groupsidik.Controls)
            {
                if (_IMG.Tag=="sidik")
                {
                    string _s = _IMG.Name.Replace("_", "");

                    switch (_s)
                    {
                        case "l1":
                            _filenamegambar[0] = _s + ".jpg";
                            break;
                        case "l2":
                            _filenamegambar[1] = _s + ".jpg";
                            break;
                        case "l3":
                            _filenamegambar[2] = _s + ".jpg";
                            break;
                        case "l4":
                            _filenamegambar[3] = _s + ".jpg";
                            break;
                        case "l5":
                            _filenamegambar[4] = _s + ".jpg";
                            break;
                        case "r1":
                            _filenamegambar[5] = _s + ".jpg";
                            break;
                        case "r2":
                            _filenamegambar[6] = _s + ".jpg";
                            break;
                        case "r3":
                            _filenamegambar[7] = _s + ".jpg";
                            break;
                        case "r4":
                            _filenamegambar[8] = _s + ".jpg";
                            break;
                        case "r5":
                            _filenamegambar[9] = _s + ".jpg";
                            break;
                    }
                    if (!_modeupdate)
                    _simpan_gambar(_IMG.Text, _proxy._GetPasien()._GetKodePasien(), _s);
                    else
                    _simpan_gambar(_IMG.Text, _kodeupdatepasien, _s);
                    _index++;
                }

            }


            //simpan ke database

            if (_modeupdate)
            {
                if (_proxy._GetPasien()._UpdatePasien(_kodeupdatepasien, _txtnamapasien.Text, _txtusia.Text,
                                                      _txttanggalanalisa.Value, _filenamegambar[0],
                                                      _filenamegambar[1], _filenamegambar[2], _filenamegambar[3],
                                                      _filenamegambar[4], _filenamegambar[5], _filenamegambar[6],
                                                      _filenamegambar[7], _filenamegambar[8], _filenamegambar[9]))
                {

                    MessageBox.Show("Update data pasien berhasil", "INFORMASI",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                                                    MessageBoxDefaultButton.Button1);
                    _EventSimpanSukses();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Penyimpanan gagal!");
                }

            }
            else
            {
                if (_proxy._GetPasien()._SimpanPasien(_txtnamapasien.Text, _txtusia.Text, _txttanggalanalisa.Value, _filenamegambar[0],
              _filenamegambar[1], _filenamegambar[2], _filenamegambar[3], _filenamegambar[4], _filenamegambar[5], _filenamegambar[6], _filenamegambar[7], _filenamegambar[8], _filenamegambar[9]))
                {
                    _dialogResult = MessageBox.Show("Apakah anda ingin melakukan entry data lagi?", "INFORMASI",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
                    if (_dialogResult == DialogResult.Yes)
                    {
                        _clear_entry();
                        _EventSimpanSukses();
                    }
                    else
                    {
                        _EventSimpanSukses();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Penyimpanan gagal!");
                }

            }

          

        }

        private void _btnbatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}