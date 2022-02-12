using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

public delegate void _lisensi_hapus();
namespace MeasureFinger
{
    public partial class FORM_LEGAL : Form
    {
        private Proxy _proxy = new Proxy();
        public event _lisensi_hapus _event_lisensi_hapus;
        public FORM_LEGAL()
        {
            InitializeComponent();
            _txtcompany.Text = _proxy._GetLic()._GetCompany();
        }

        private void _btn_keluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _btn_hapus_lisensi_Click(object sender, EventArgs e)
        {
            DialogResult _dl = MessageBox.Show("Apakah anda ingin menghilangkan lisensi anda?", "Warning system",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(_dl==DialogResult.Yes)
            {
                if (_proxy._GetLic()._HapusLisensi())
                {
                    MessageBox.Show("Lisensi berhasil dihapus!", "Warning system", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Lisensi gagal dihapus!", "Warning system", MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                }
            }
        }
    }
}
