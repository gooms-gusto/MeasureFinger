﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DAL;
using Hitungan;

namespace MeasureFinger
{
    public partial class FORM_UKUR : Form
    {
        private Proxy _proxy = new Proxy();
        private string _current_jari;
        private string _ID;
        Point firstPoint;
        Point secondPoint;
        private string filegambar;
        private int _wizardposition = 1;
        private DataTable _DataSelectedPasien;
        private ProsesHitungan _analys = new ProsesHitungan();
        private GlobalClass _Myglobal = new GlobalClass();

        public FORM_UKUR(string ID)
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(FORM_UKUR_Closing);
            _PicSidikJari.MouseDown += new MouseEventHandler(_PicSidikJari_MouseDown);
            _PicSidikJari.Paint += new PaintEventHandler(_PicSidikJari_Paint);
          
            
            _ID = ID;

            _DataSelectedPasien = _proxy._GetPasien()._SelectPasien(_ID, "");
            _txtnamapasien.Text = _DataSelectedPasien.Rows[0]["NAMA_PASIEN"].ToString();
            _txtusiapasien.Text = _DataSelectedPasien.Rows[0]["USIA"].ToString();

            _TxtHasilUkur.Text = "0";
            _LoadDataUkur();
            _Wizard(1);


            _BtnKembali.Enabled = false;
            _BtnBerikutnya.Enabled = true;

        }

        void FORM_UKUR_Closing(object sender, CancelEventArgs e)
        {
            _PicSidikJari.Dispose();
        }

        void _PicSidikJari_Paint(object sender, PaintEventArgs e)
        {
            Pen pn = new Pen(Color.DarkOrange,2);
            e.Graphics.DrawLine(pn, firstPoint, secondPoint);
            
        }

        void _PicSidikJari_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.firstPoint.IsEmpty == true && this.secondPoint.IsEmpty == true)
            {
                this.firstPoint = e.Location;
                return;
            }

            if (this.secondPoint.IsEmpty == true && this.firstPoint.IsEmpty == false)
            {
                this.secondPoint = e.Location;
            }

            _PicSidikJari.Invalidate();

            if (firstPoint.IsEmpty == false && secondPoint.IsEmpty == false)
                _TxtHasilUkur.Text = DistanceBetweenPoints(firstPoint, secondPoint).ToString();
        } 
        
        public double DistanceBetweenPoints(Point Point1, Point Point2)
        {
            return Math.Round(Math.Sqrt(Math.Pow((Point1.X - Point2.X), 2) + Math.Pow((Point1.Y - Point2.Y), 2)) * 0.264583,2);
        }


        void _LoadDataUkur()
        {
            DataTable _dtUkur = _proxy._GetPasien()._SelectDataUkur(_ID);
            _DgSidikUkur.DataSource = _dtUkur;
            _DgSidikUkur.AutoSizeCols();

            if (_dtUkur.Rows.Count == 0)
                return;
        }

        void _CreatePictureBox()
        {
            try
            {
                firstPoint = new Point();
                secondPoint = new Point();
                _PicSidikJari = new PictureBox();
                this._PicSidikJari.Location = new System.Drawing.Point(92, 102);
                this._PicSidikJari.Name = "_PicSidikJari";
                this._PicSidikJari.Size = new System.Drawing.Size(329, 329);
                this._PicSidikJari.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this._PicSidikJari.TabIndex = 0;
                this._PicSidikJari.TabStop = false;
                this._PicSidikJari.Cursor = System.Windows.Forms.Cursors.Cross;
                this.groupBox1.Controls.Add(this._PicSidikJari);
                this._PicSidikJari.MouseDown += new MouseEventHandler(_PicSidikJari_MouseDown);
                this._PicSidikJari.Paint += new PaintEventHandler(_PicSidikJari_Paint);
                _Wizard(_wizardposition);
            }
            catch (Exception)
            {
            }

        }

        void _Wizard(int posisi)
        {
            try
            {
               

                string _previx_jari;
                string _numberjari;

                DataTable _item = _proxy._GetPasien()._SelectDataUkur(_ID);

                if (posisi <6)
                {
                    _previx_jari = "l";
                    _numberjari = posisi.ToString();
                }
                else
                {
                    _previx_jari = "r";
                    _numberjari = (posisi - 5).ToString();
                }
                _TxtPosisi.Text = (_previx_jari + _numberjari).ToUpper();
                _current_jari = _previx_jari + _numberjari;
                _LoadImage(_previx_jari + _numberjari);
                if (string.IsNullOrEmpty(_item.Rows[0][_previx_jari + _numberjari].ToString()))
                    _TxtHasilUkur.Text = "0";
                else
                    _TxtHasilUkur.Text = _item.Rows[0][_previx_jari + _numberjari].ToString();

                for (int _puter = 1; _puter < 11;_puter++ )
                {
                    if (_puter==_wizardposition)
                    {
                        _DgSidikUkur.Cols[_puter].StyleDisplay.BackColor = Color.DarkOrange;

                    }
                    else
                    {
                        _DgSidikUkur.Cols[_puter].StyleDisplay.BackColor = Color.Yellow;
                        
                    }
                }

            }
            catch (Exception)
            {

            }


        }

        void _LoadImage(string _LabelJari)
        {
            try
            {
                FileStream fs;
                filegambar = ModuleStatic.GetPathGambar + "\\" + _ID + "\\" + _LabelJari + ".jpg";
               
                if (File.Exists(filegambar))
                {
                    filegambar = ModuleStatic.GetPathGambar + "\\" + _ID + "\\" + _LabelJari + ".jpg";
                }
                else
                {
                    filegambar=ModuleStatic.GetPathGambar + "\\nopic.jpg";
                }

                 fs = new FileStream(filegambar, FileMode.Open);
                 _PicSidikJari.Image = Image.FromStream(fs);
                 fs.Close();
            }
            catch (Exception)
            {

            }

        }

        

        private void _BtnBatalUkuran_Click(object sender, EventArgs e)
        {
            _TxtHasilUkur.Text = "0";
            _PicSidikJari.Dispose();

            _CreatePictureBox();

        

        }

        private void _BtnSimpanUkuran_Click(object sender, EventArgs e)
        {
          if (this.firstPoint.IsEmpty == true || this.secondPoint.IsEmpty == true)
          {
              MessageBox.Show("Data ukur masih kosong!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              firstPoint = new Point();
              secondPoint = new Point();
              return;

          }


            if (_proxy._GetPasien()._UpdateSidikJari(_ID,_current_jari, _TxtHasilUkur.Text))
            { 
                MessageBox.Show("Data berhasil disimpan","Information",MessageBoxButtons.OK,MessageBoxIcon.Information );
                if (_wizardposition==10)
                {
                    this.Close();
                }
                else
                {
                    _LoadDataUkur();
                    _PicSidikJari.Dispose();
                    _CreatePictureBox();
                    _wizardposition++;
                    _Wizard(_wizardposition);
                }
                }
            else
                MessageBox.Show("Data gagal disimpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }

        private void _BtnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _BtnKembali_Click(object sender, EventArgs e)
        {
            _BtnBatalUkuran_Click(null, null);
            _wizardposition--;
            if (_wizardposition ==1 )
            {
                _BtnKembali.Enabled = false;
            }
            else
            {
                _BtnBerikutnya.Enabled = true;
            }

           _Wizard(_wizardposition);

        }

        private void _BtnBerikutnya_Click(object sender, EventArgs e)
        {
            _BtnBatalUkuran_Click(null, null);
            _wizardposition++;
            if (_wizardposition > 1)
            {
                _BtnKembali.Enabled = true;
            }
            if (_wizardposition ==10)
            {
                _BtnBerikutnya.Enabled = false;
            }
            _Wizard(_wizardposition);
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(_analys._HitungProsentaseOtakKiri(_ID).ToString());
            MessageBox.Show(_analys._HitungProsentasePengamatan(_ID).ToString());

        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_analys._HitungProsentaseOtakKanan(_ID).ToString());
        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            Hitung _hitung = new Hitung();

            double _total = _hitung.GetGayaKerja().GetEksekutorDanPelaksana(_ID) +
                            _hitung.GetGayaKerja().GetInisiatorDanPemimpin(_ID) +
                            _hitung.GetGayaKerja().GetKomunikator(_ID) +
                            _hitung.GetGayaKerja().GetPengamatan(_ID) +
                            _hitung.GetGayaKerja().GetPengonsepDanPengelola(_ID);
                           
           MessageBox.Show(_total.ToString());
        }


    }
}