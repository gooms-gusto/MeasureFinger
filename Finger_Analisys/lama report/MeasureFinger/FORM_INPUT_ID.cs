using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
namespace MeasureFinger 
{
    public partial class FORM_INPUT_ID : Form
    {
        private Proxy _proxy = new Proxy();
        private string _KodePasien;
        public FORM_INPUT_ID(string KodePasien)
        {
            InitializeComponent();
            _KodePasien = KodePasien;
            _TxtNomorCetak.Text = _proxy._GetPasien()._SelectIDAlias(KodePasien);
        }

        private void _BtnSimpan_Click(object sender, EventArgs e)
        {
            if (_TxtNomorCetak.Text==string.Empty)
            {
                MessageBox.Show("ID masih kosong!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _TxtNomorCetak.Focus();
                return;
            }
            
            if (_proxy._GetPasien()._UpdateIDAlias(_KodePasien,_TxtNomorCetak.Text))
            {
                MessageBox.Show("ID Pasien berhasil disimpan!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Simpan gagal!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _TxtNomorCetak.Focus();
            }

        }

        private void _BtnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      


    }
}
