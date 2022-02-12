using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EncrytionHash;
namespace KeyGenerator
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void _BtnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_TxtNomorSeri.Text))
            {
                MessageBox.Show("Nomor seri masih kosong!");
                _TxtNomorSeri.Focus();
                return;
            }

            _TxtKey.Text = Kunci.Encrypt(_TxtNomorSeri.Text);
        }

        private void _btn_new_Click(object sender, EventArgs e)
        {
            _TxtKey.Text = string.Empty;
            _TxtNomorSeri.Text = string.Empty;
            _TxtNomorSeri.Focus();

        }

        private void _BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





    }
}
