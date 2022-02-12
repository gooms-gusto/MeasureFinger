using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Hitungan;
using DAL;

namespace MeasureFinger
{
    public partial class FORM_OUTPUTANALISA : Form
    {
        private Hitung _hitung = new Hitung();
        private string _KodePasien;
        private Proxy _proxy = new Proxy();
        public FORM_OUTPUTANALISA(string KodePasien)
        {
            InitializeComponent();
            _KodePasien = KodePasien;
            _ShowDetailData(KodePasien);
        }

        void _ShowDetailData(string KodePasien)
        {

            _flex.Cols[1].TextAlign = TextAlignEnum.LeftCenter;
            _flex.Cols[3].TextAlign = TextAlignEnum.RightCenter;
            _flex.Cols[3].StyleDisplay.ForeColor = Color.DarkGreen;
            _flex.Cols[3].StyleDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            DataTable _DataSelectedPasien = _proxy._GetPasien()._SelectPasien(KodePasien, "");
            _txt_nama.Text = _DataSelectedPasien.Rows[0]["NAMA_PASIEN"].ToString();
            _txt_usia.Text = _DataSelectedPasien.Rows[0]["USIA"].ToString();
            _flex.AllowMerging = AllowMergingEnum.Free;
            // dominasi otak Grid
            _flex.Cols.Count = 5;
            _flex.Rows.Count = 0;
            _flex.AddItem("\t\t\t\t\t");
            _flex.AddItem("\tDominasi Otak\tDominasi Otak\tDominasi Otak\tDominasi Otak");
            _flex.Rows.Fixed = 1;
            _flex.AddItem("\tOtak Kiri\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(KodePasien) + _hitung.GetPotentisialSkill().GetBahasa(KodePasien) + _hitung.GetPotentisialSkill().GetTeknikGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetLogikaMatematika(KodePasien) + _hitung.GetPotentisialSkill().GetTataKepribadian(KodePasien), 2).ToString() + "\t%");
            _flex.AddItem("\tOtak Kanan\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(KodePasien) + _hitung.GetPotentisialSkill().GetMusik(KodePasien) + _hitung.GetPotentisialSkill().GetSeniGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(KodePasien) + _hitung.GetPotentisialSkill().GetHubunganSosial(KodePasien), 2).ToString() + "\t%");
           

            // add some formatting
            _flex.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            _flex.Styles.Normal.TextAlign = TextAlignEnum.CenterCenter;
           
            _flex.Rows[1].AllowMerging = true;
            _flex.Rows[1].StyleNew.BackColor = Color.DarkOrange;
            _flex.AutoSizeCols();

            // gaya belajar Grid
            _flex.AddItem("\t\t\t\t\t");
            _flex.AddItem("\tGaya Belajar\tGaya Belajar\tGaya Belajar\tGaya Belajar");
            _flex.Rows[5].AllowMerging = true;
            _flex.Rows[5].StyleNew.BackColor = Color.DarkOrange;
            _flex.AddItem("\tVisual Teks\t:\t" + Math.Round(_hitung.GetGayaBelajar().GetVisualTeks(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tVisual Gambar\t:\t" + Math.Round(_hitung.GetGayaBelajar().GetVisualGambar(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tAuditori Bahasa\t:\t" + Math.Round(_hitung.GetGayaBelajar().GetAuditoriBahasa(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tAuditori Musik\t:\t" + Math.Round(_hitung.GetGayaBelajar().GetAuditoriMusik(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tKinestatik sentuhan\t:\t" + Math.Round(_hitung.GetGayaBelajar().GetAuditoriBahasa(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tKinestatik gerakan\t:\t" + Math.Round(_hitung.GetGayaBelajar().GetAuditoriBahasa(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tVisual Auditori Bahasa\t:\t" + Math.Round(_hitung.GetGayaBelajar().GetAuditoriBahasa(_KodePasien), 4).ToString() + "\t%");



            // gaya kerja Grid
            _flex.AddItem("\t\t\t\t\t");
            _flex.AddItem("\tGaya Kerja\tGaya Kerja\tGaya Kerja\tGaya Kerja");
            _flex.Rows[14].AllowMerging = true;
            _flex.Rows[14].StyleNew.BackColor = Color.DarkOrange;
            _flex.AddItem("\tPengamatan\t:\t" + Math.Round(_hitung.GetGayaKerja().GetPengamatan(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tKomunikator\t:\t" + Math.Round(_hitung.GetGayaKerja().GetKomunikator(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tEksekutor\t:\t" + Math.Round(_hitung.GetGayaKerja().GetEksekutorDanPelaksana(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tInisiator Pemimpin\t:\t" + Math.Round(_hitung.GetGayaKerja().GetInisiatorDanPemimpin(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tPengonsep\t:\t" + Math.Round(_hitung.GetGayaKerja().GetPengonsepDanPengelola(_KodePasien), 4).ToString() + "\t%");


            // potensial skill
            _flex.AddItem("\t\t\t\t\t");
            _flex.AddItem("\tPotensial Kerja\tPotensial Kerja\tPotensial Kerja\tPotensial Kerja");
            _flex.Rows[21].AllowMerging = true;
            _flex.Rows[21].StyleNew.BackColor = Color.DarkOrange;
            _flex.AddItem("\tVisual Teknik\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tVisual Seni\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tBahasa\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetBahasa(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tMusik\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetMusik(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tTeknik Gerakan\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetTeknikGerakan(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tSeni Gerakan\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetSeniGerakan(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tLogika Matematika\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetLogikaMatematika(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tIntuisi dan Kreativitas\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tTata Kepribadian\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetTataKepribadian(_KodePasien), 4).ToString() + "\t%");
            _flex.AddItem("\tHubungan Sosial\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetHubunganSosial(_KodePasien), 4).ToString() + "\t%");
           


            _flex.AutoSizeCols();


            // update nilai

            _proxy._GetPasien()._UpdateDominasiOtak(KodePasien, Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(KodePasien) + _hitung.GetPotentisialSkill().GetBahasa(KodePasien) + _hitung.GetPotentisialSkill().GetTeknikGerakan(KodePasien) +
                  _hitung.GetPotentisialSkill().GetLogikaMatematika(KodePasien) + _hitung.GetPotentisialSkill().GetTataKepribadian(KodePasien), 2), Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(KodePasien) + _hitung.GetPotentisialSkill().GetMusik(KodePasien) + _hitung.GetPotentisialSkill().GetSeniGerakan(KodePasien) +
                  _hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(KodePasien) + _hitung.GetPotentisialSkill().GetHubunganSosial(KodePasien), 2));


            _proxy._GetPasien()._UpdateGayaBelajar(KodePasien,
                                                 Math.Round(_hitung.GetGayaBelajar().GetVisualTeks(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaBelajar().GetVisualGambar(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaBelajar().GetAuditoriBahasa(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaBelajar().GetAuditoriMusik(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaBelajar().GetKinestatikSentuhan(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaBelajar().GetKinestatikGerakan(_KodePasien), 4));

            _proxy._GetPasien()._UpdateGayaKerja(KodePasien,
                                             Math.Round(_hitung.GetGayaKerja().GetPengamatan(_KodePasien), 4),
                                             Math.Round(_hitung.GetGayaKerja().GetKomunikator(_KodePasien), 4),
                                             Math.Round(_hitung.GetGayaKerja().GetEksekutorDanPelaksana(_KodePasien), 4),
                                             Math.Round(_hitung.GetGayaKerja().GetInisiatorDanPemimpin(_KodePasien), 4),
                                             Math.Round(_hitung.GetGayaKerja().GetPengonsepDanPengelola(_KodePasien), 4));

            _proxy._GetPasien()._UpdateKecenderunganBakat(KodePasien,
                                                        Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetBahasa(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetMusik(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetTeknikGerakan(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetSeniGerakan(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetLogikaMatematika(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetTataKepribadian(_KodePasien), 4),
                                                        Math.Round(_hitung.GetPotentisialSkill().GetHubunganSosial(_KodePasien), 4));

          
        }

        private void _BtnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _BtnKecenderunganOtak_Click(object sender, EventArgs e)
        {
            FORM_KECEDERUNGAN_OTAK _formKecederunganOtak = new FORM_KECEDERUNGAN_OTAK(_KodePasien);
            _formKecederunganOtak.ShowDialog();
        }

        private void _btn_input_id_Click(object sender, EventArgs e)
        {
            FORM_INPUT_ID _formInputId = new FORM_INPUT_ID(_KodePasien);
            _formInputId.ShowDialog();
        }

        private void _BtnCetak_Click(object sender, EventArgs e)
        {
            if (!_proxy._GetPasien()._ValidasiCortexPasien(_KodePasien))
            {
                MessageBox.Show("Nilai kecenderungan otak belum diisi!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_proxy._GetPasien()._ValidasiIDPasien(_KodePasien))
            {
                MessageBox.Show("ID Pasien belum diisi!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CanvasReport _canvasReport = new CanvasReport(_KodePasien);
            _canvasReport.ShowDialog();
        }
    }
}
