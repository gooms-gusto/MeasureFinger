using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EncrytionHash;

using DAL;

namespace MeasureFinger
{
    public partial class FORM_LISENSI : Form
    {

   
        private EncrytionHash.Kunci _lock = new Kunci();
        private Proxy _proxy = new Proxy();
       
        public FORM_LISENSI()
        {
            InitializeComponent();
            _txt_no_seri.Text = _proxy._GetHardware()._GetNomerSeri();

        }

        bool validasi()
        {
            if (_proxy._GetHardware()._GetValue().Trim()==_txt_key.Text.Trim())
            {
                return true;
            }
            return false;
        }

        private void _btn_register_Click(object sender, EventArgs e)
        {
            //jika trial
            if (ModuleStatic.GetSetTrial)
                this.Close();
            else
            {
                if (!validasi())
                {
                    MessageBox.Show(
                        "Nomor register anda salah! silakan hubungi contact person (+6281-235-5959-34 / akbar.ardiansah@gmail.com).",
                        "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (_txt_perusahaan.Text == string.Empty)
                {
                    MessageBox.Show(
                        "Nama perusahaan harus diisi!",
                        "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (_proxy._GetLic()._RegisterLisensi(_txt_key.Text.Trim(), _txt_perusahaan.Text))
                {
                    MessageBox.Show(
                        "Registrasi sukses, simpan nomer lisensi produk untuk sewaktu-waktu bila diperlukan, terima kasih.",
                        "Informasi system", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void _Btn_Batal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _CkTrial_CheckedChanged(object sender, EventArgs e)
        {
            ModuleStatic.GetSetTrial = _CkTrial.Checked;
        }
    }
}
