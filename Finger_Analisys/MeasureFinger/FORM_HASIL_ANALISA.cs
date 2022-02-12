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

   
    public partial class FORM_HASIL_ANALISA : Form
    {
        private Hitung _hitung = new Hitung();
        private string _KodePasien;
        private Proxy _proxy = new Proxy();
        public FORM_HASIL_ANALISA(string KodePasien)
        {
            InitializeComponent();
            _KodePasien = KodePasien;
            _ShowDetailData(KodePasien);
        }


        void _SaveComponent(string KodePasien)
        {
            
        }

        void _ShowDetailData(string KodePasien)
        {

           DataTable   _DataSelectedPasien = _proxy._GetPasien()._SelectPasien(KodePasien, "");
            _txt_nama.Text = _DataSelectedPasien.Rows[0]["NAMA_PASIEN"].ToString();
            _txt_usia.Text = _DataSelectedPasien.Rows[0]["USIA"].ToString();

            // dominasi otak Grid

            _flex.Cols.Count = 5;
            _flex.Rows.Count = 0;
            //_flex.AddItem("\t\t\t");
            _flex.AddItem("\tDominasi Otak\tDominasi Otak\tDominasi Otak\tDominasi Otak");
            _flex.Rows.Fixed = 1;
            _flex.AddItem("\tOtak Kiri\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(KodePasien) + _hitung.GetPotentisialSkill().GetBahasa(KodePasien) + _hitung.GetPotentisialSkill().GetTeknikGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetLogikaMatematika(KodePasien) + _hitung.GetPotentisialSkill().GetTataKepribadian(KodePasien), 2).ToString() + "\t%");
            _flex.AddItem("\tOtak Kanan\t:\t" + Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(KodePasien) + _hitung.GetPotentisialSkill().GetMusik(KodePasien) + _hitung.GetPotentisialSkill().GetSeniGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(KodePasien) + _hitung.GetPotentisialSkill().GetHubunganSosial(KodePasien), 2).ToString() + "\t%");
           _flex.Cols[1].TextAlign=TextAlignEnum.LeftCenter;
            
            // add some formatting
            _flex.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            _flex.Styles.Normal.TextAlign = TextAlignEnum.CenterCenter;
           
            
           
            _flex.AllowMerging = AllowMergingEnum.Free;
            for (int i = 1; i < 1; i++)
                _flex.Cols[i].AllowMerging = true;
            for (int i = 0; i < _flex.Rows.Count; i++)
                _flex.Rows[i].AllowMerging = true;

            _flex.AutoSizeCols();
           // dominasi otak

            _txt_otak_kanan.Text = Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(KodePasien) +_hitung.GetPotentisialSkill().GetMusik(KodePasien) + _hitung.GetPotentisialSkill().GetSeniGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(KodePasien) + _hitung.GetPotentisialSkill().GetHubunganSosial(KodePasien),2).ToString();
            _txt_otak_kiri.Text = Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(KodePasien) + _hitung.GetPotentisialSkill().GetBahasa(KodePasien) + _hitung.GetPotentisialSkill().GetTeknikGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetLogikaMatematika(KodePasien) + _hitung.GetPotentisialSkill().GetTataKepribadian(KodePasien),2).ToString();

            _proxy._GetPasien()._UpdateDominasiOtak(KodePasien, Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(KodePasien) + _hitung.GetPotentisialSkill().GetBahasa(KodePasien) + _hitung.GetPotentisialSkill().GetTeknikGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetLogikaMatematika(KodePasien) + _hitung.GetPotentisialSkill().GetTataKepribadian(KodePasien),2), Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(KodePasien) + _hitung.GetPotentisialSkill().GetMusik(KodePasien) + _hitung.GetPotentisialSkill().GetSeniGerakan(KodePasien) +
                       _hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(KodePasien) + _hitung.GetPotentisialSkill().GetHubunganSosial(KodePasien),2));



            // gaya belajar
            

            _txt_visual_teks.Text =Math.Round(_hitung.GetGayaBelajar().GetVisualTeks(_KodePasien),4).ToString() ;
            _txt_visual_gambar.Text = Math.Round(_hitung.GetGayaBelajar().GetVisualGambar(_KodePasien), 4).ToString() ;
            _txt_auditori_bahasa.Text = Math.Round(_hitung.GetGayaBelajar().GetAuditoriBahasa(_KodePasien), 4).ToString() ;
            _txt_auditori_musik.Text = Math.Round(_hitung.GetGayaBelajar().GetAuditoriMusik(_KodePasien), 4).ToString() ;
            _txt_kinestatik_sentuhan.Text = Math.Round(_hitung.GetGayaBelajar().GetKinestatikSentuhan(_KodePasien), 4).ToString() ;
            _txt_kinestatik_gerakan.Text = Math.Round(_hitung.GetGayaBelajar().GetKinestatikGerakan(_KodePasien), 4).ToString() ;

            _proxy._GetPasien()._UpdateGayaBelajar(KodePasien,
                                                   Math.Round(_hitung.GetGayaBelajar().GetVisualTeks(_KodePasien), 4),
                                                   Math.Round(_hitung.GetGayaBelajar().GetVisualGambar(_KodePasien), 4),
                                                   Math.Round(_hitung.GetGayaBelajar().GetAuditoriBahasa(_KodePasien), 4),
                                                   Math.Round(_hitung.GetGayaBelajar().GetAuditoriMusik(_KodePasien), 4),
                                                   Math.Round(_hitung.GetGayaBelajar().GetKinestatikSentuhan(_KodePasien), 4),
                                                   Math.Round(_hitung.GetGayaBelajar().GetKinestatikGerakan(_KodePasien), 4));




            // gaya kerja

            _txt_pengamatan.Text = Math.Round(_hitung.GetGayaKerja().GetPengamatan(_KodePasien), 4).ToString() ;
            _txt_komunikator.Text= Math.Round(_hitung.GetGayaKerja().GetKomunikator(_KodePasien), 4).ToString() ;
            _txt_eksekutor.Text= Math.Round(_hitung.GetGayaKerja().GetEksekutorDanPelaksana(_KodePasien), 4).ToString() ;
            _txt_inisator_pemimpin.Text= Math.Round(_hitung.GetGayaKerja().GetInisiatorDanPemimpin(_KodePasien), 4).ToString() ;
            _txt_pengonsep.Text = Math.Round(_hitung.GetGayaKerja().GetPengonsepDanPengelola(_KodePasien), 4).ToString() ;

            _proxy._GetPasien()._UpdateGayaKerja(KodePasien,
                                                 Math.Round(_hitung.GetGayaKerja().GetPengamatan(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaKerja().GetKomunikator(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaKerja().GetEksekutorDanPelaksana(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaKerja().GetInisiatorDanPemimpin(_KodePasien), 4),
                                                 Math.Round(_hitung.GetGayaKerja().GetPengonsepDanPengelola(_KodePasien), 4));






                // potensial skill


                _txt_visual_teknik.Text=Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(_KodePasien), 4).ToString() ;
                _txt_visual_seni.Text=Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(_KodePasien), 4).ToString() ;
                _txt_bahasa.Text=Math.Round(_hitung.GetPotentisialSkill().GetBahasa(_KodePasien), 4).ToString() ;
                _txt_musik.Text=Math.Round(_hitung.GetPotentisialSkill().GetMusik(_KodePasien), 4).ToString() ;
                _txt_teknik_gerakan.Text=Math.Round(_hitung.GetPotentisialSkill().GetTeknikGerakan(_KodePasien), 4).ToString() ;
                _txt_seni_gerakan.Text=Math.Round(_hitung.GetPotentisialSkill().GetSeniGerakan(_KodePasien), 4).ToString() ;
                _txt_logika_matematika.Text=Math.Round(_hitung.GetPotentisialSkill().GetLogikaMatematika(_KodePasien), 4).ToString() ;
                _txt_intuisi_kreativitas.Text=Math.Round(_hitung.GetPotentisialSkill().GetIntuisiDanKreatifitas(_KodePasien), 4).ToString() ;
                _txt_tata_kepribadian.Text=Math.Round(_hitung.GetPotentisialSkill().GetTataKepribadian(_KodePasien), 4).ToString() ;
                _txt_hubungan_sosial.Text = Math.Round(_hitung.GetPotentisialSkill().GetHubunganSosial(_KodePasien), 4).ToString() ;

                _proxy._GetPasien()._UpdateKecenderunganBakat(KodePasien,
                                                          Math.Round(_hitung.GetPotentisialSkill().GetVisualTeknik(_KodePasien), 4),
                                                          Math.Round(_hitung.GetPotentisialSkill().GetVisualSeni(_KodePasien),4),
                                                          Math.Round(_hitung.GetPotentisialSkill().GetBahasa(_KodePasien), 4),
                                                          Math.Round(_hitung.GetPotentisialSkill().GetMusik(_KodePasien), 4),
                                                          Math.Round(_hitung.GetPotentisialSkill().GetTeknikGerakan(_KodePasien),4),
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

        private void _BtnCetak_Click(object sender, EventArgs e)
        {
            if (!_proxy._GetPasien()._ValidasiCortexPasien(_KodePasien))
            {
                MessageBox.Show("Nilai kecenderungan otak belum diisi!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_proxy._GetPasien()._ValidasiIDPasien( _KodePasien))
            {
                MessageBox.Show("ID Pasien belum diisi!", "Warning system", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            CanvasReport _canvasReport = new CanvasReport(_KodePasien);
            _canvasReport.ShowDialog();
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


    }
}
