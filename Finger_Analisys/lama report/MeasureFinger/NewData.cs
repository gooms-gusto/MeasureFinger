using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.IO;
namespace MeasureFinger
{
    public partial class NewData : UserControl
    {
        private Proxy _proxy = new Proxy();

        public NewData()
        {
            InitializeComponent();
          _fill_grid("", "");
            _cbpencarian.SelectedIndex = 0;
        }

        private void _BSimpan_Click(object sender, EventArgs e)
        {
            //if (_proxy._GetPasien()._SimpanPasien(_txtnama.Text,_txtusia.Text,_tanggal_pengujian.Value))
            //{
            //    _fill_grid("", "");
            //    _clear();
            //    _BtnBatal_Click(null,null);
            //}
        }

        private void _BtnPasienBru_Click(object sender, EventArgs e)
        {
            _GroupEntryPasien.Enabled = true;
            _txt_idpasien.Text = _proxy._GetPasien()._GetKodePasien();
            _tanggal_pengujian.Select();
            _BtnPasienBru.Enabled = false;
            _BtnSimpan.Enabled = true;
            _BtnBatal.Enabled = true;
        }

        private void _clear()
        {
            _txt_idpasien.Text = string.Empty;
            _txtnama.Text = string.Empty;
            _txtusia.Text = string.Empty;
        }

        private void _fill_grid(string _ParamID,string _ParamNama)
        {
            try
            {
                _dgrid.DataSource = _proxy._GetPasien()._SelectPasien(_ParamID, _ParamNama );
                _dgrid.Cols[2].Visible = false;
                _dgrid.Cols[4].Visible = false;
                _dgrid.AutoSizeCols();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void _txtnama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _txtusia.Select();
        }

        private void _txtusia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _BtnSimpan.Select();
        }

        private void _tanggal_pengujian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _txtnama.Select();
        }

        private void _BtnBatal_Click(object sender, EventArgs e)
        {
            _clear();
            _tanggal_pengujian.Value = System.DateTime.Now;
            _GroupEntryPasien.Enabled = false;
            _BtnSimpan.Enabled = false;
            _BtnBatal.Enabled = false;
            _BtnPasienBru.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("c:\\b.jpg", FileMode.Open, FileAccess.Read);
            int sizee = (int)fs.Length;
            byte[] rawData = new byte[sizee + 1];
            fs.Read(rawData, 0, sizee);
            fs.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }
    }
}
