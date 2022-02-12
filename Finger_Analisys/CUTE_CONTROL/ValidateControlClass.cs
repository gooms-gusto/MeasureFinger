using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

    public class ValidateControlClass
    {
        private static ErrorProvider _error = new ErrorProvider();
        public static bool _validatetrue(System.Windows.Forms.Control.ControlCollection _ctxs,ErrorProvider _provider)
        {
            try
            {
                int _error_count = 0;
                int jumlah = _ctxs.Count;
                _error = _provider;
                foreach(Control _ctx in _ctxs)
                {
                    _ctx.Validating += new System.ComponentModel.CancelEventHandler(_ctx_Validating);
                    if (_ctx.Tag=="in")
                    {
                        if (_ctx.Text.Length==0)
                        {
                            _provider.SetError(_ctx, "Tidak Boleh Kosong");
                            _error_count++;
                        }
                        else
                        {
                            _provider.SetError(_ctx, "");
                        }
                    }
                }
                if (_error_count >0)
                    return false;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        static void _ctx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Control _ctx = (Control) sender;

            if (_ctx.Tag != "in")
                return;

            if (_ctx.Text.Length == 0)
            {
                _error.SetError(_ctx, "Tidak Boleh Kosong");
            }
            else
            {
                _error.SetError(_ctx, "");
            }

        }
    }

