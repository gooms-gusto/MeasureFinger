using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EncrytionHash;
namespace EncryptTool
{
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
        }

        private void _BtnEncrypt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_D_T1.Text))
                _D_T2.Text = EncrytionHash.Kunci.Encrypt(_D_T1.Text);
        }

        private void _BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_E_T1.Text))
                _E_T2.Text = EncrytionHash.Kunci.Decrypt(_E_T1.Text);
        }
    }
}
