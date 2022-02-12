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
    public partial class FORM_UBAH_PASSWORD : Form
    {
        private Proxy _proxy = new Proxy();
        public FORM_UBAH_PASSWORD()
        {
            InitializeComponent();
        }

        private void _btn_ubah_Click(object sender, EventArgs e)
        {
            if (_txt_password.Text == string.Empty)
            {
                MessageBox.Show("Password masih kosong!", "Warning system", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            if (_proxy._GetLogin()._UbahPassword(_txt_password.Text))
            { MessageBox.Show("Password berhasil dirubah!", "Warning system", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
              this.Close();
            }
            else
            {
                MessageBox.Show("Password gagal dirubah!", "Warning system", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop); 
            }
        }

        private void _txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if (e.KeyChar==13)
            {
                if (_txt_password.Text == string.Empty)
                {
                    MessageBox.Show("Password masih kosong!", "Warning system", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    return;
                }


                if (_proxy._GetLogin()._UbahPassword(_txt_password.Text))
                { MessageBox.Show("Password berhasil dirubah!", "Warning system", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password gagal dirubah!", "Warning system", MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                }

            }
        }

        private void _btn_batal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
