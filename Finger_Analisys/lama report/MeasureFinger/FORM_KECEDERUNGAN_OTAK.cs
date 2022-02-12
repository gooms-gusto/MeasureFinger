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
    public partial class FORM_KECEDERUNGAN_OTAK : Form
    {
        private Proxy _proxy = new Proxy();
        private string KodePasien;
        public FORM_KECEDERUNGAN_OTAK(string IdPasien)
        {
            InitializeComponent();
            KodePasien = IdPasien;
            _GridKecenderunganOtak.DataSource = _proxy._GetPasien()._SelectKencederunganOtak(IdPasien);
            _TxtBrainStem.Select();
        }

        
        void Validasi()
        {
            double _satu = string.IsNullOrEmpty(_TxtBrainStem.Text) ? 0 : Convert.ToDouble(_TxtBrainStem.Text);
            double _dua = string.IsNullOrEmpty(_TxtLimbik.Text) ? 0 : Convert.ToDouble(_TxtLimbik.Text);
            double _tiga = string.IsNullOrEmpty(_TxtKortex.Text) ? 0 : Convert.ToDouble(_TxtKortex.Text);

            double _result = _satu + _dua + _tiga;

            if (_result==100)
            {
                if (_proxy._GetPasien()._UpdateKecenderunganOtak(KodePasien,_satu,_dua,_tiga))
                {
                    _GridKecenderunganOtak.DataSource = _proxy._GetPasien()._SelectKencederunganOtak(KodePasien);
                    MessageBox.Show("Data kecenderungan otak berhasil disimpan", "Informasi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Total prosentasi tidak sama dengan 100%, mohon cek kembali", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _TxtBrainStem.Select();
                _TxtBrainStem.Text = string.Empty;
                _TxtKortex.Text = string.Empty;
                _TxtLimbik.Text = string.Empty;
                _TxtBrainStem.Select();
            }


        }

        private void _BtnSimpan_Click(object sender, EventArgs e)
        {
            Validasi();
        }

        private void _BtnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _TxtBrainStem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                _TxtLimbik.Select();
            }
        }

        private void _TxtLimbik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _TxtKortex.Select();
            }
        }

        private void _TxtKortex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                _BtnSimpan.Focus();
        }

        

    }
}
