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
    public partial class FORM_LOGIN : Form
    {
        private Proxy _proxy = new Proxy();
        private bool _expired = false;

        public FORM_LOGIN()
        {
            InitializeComponent();

            if (_proxy._GetLimit()._AktifLimit())
            {
                _expired = _proxy._GetLimit()._Expired();
            }
        }

    

        private void _btn_oke_Click(object sender, EventArgs e)
        {
            if (_expired)
            {
                MessageBox.Show("Password salah!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }


            if (_proxy._GetLogin()._ValidateLogin(_txt_password.Text))
                this.Close();
            else
            { MessageBox.Show("Password salah!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                _txt_password.Text = string.Empty;
                _txt_password.Select();
            }
         }

        private void _txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar==13)
            {
                if (_expired)
                {
                    MessageBox.Show("Password salah!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }


                if (_proxy._GetLogin()._ValidateLogin(_txt_password.Text))
                {
                    if (!_expired)
                        _proxy._GetLimit()._UpdateCount();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password salah!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    _txt_password.Text = string.Empty;
                    _txt_password.Select();
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void _btn_batal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
