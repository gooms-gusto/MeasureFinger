using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace CUTE_CONTROL
{
    public partial class NumericTexboxt : TextBox
    {
        public NumericTexboxt()
        {
            InitializeComponent();
        }

        public NumericTexboxt(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



      

        private void NumericTexboxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt16(e.KeyChar).ToString() == "8")
            { e.Handled = false; return; }


            if (!(Char.IsNumber(e.KeyChar)))
                e.Handled = true;
        }
         
       
    }
}
