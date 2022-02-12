using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CUTE_CONTROL
{
    public partial class Tanggal : UserControl
    {
        private string _Tanggal;
        private string _Bulan;
        private string _Tahun;

        public Tanggal()
        {
            InitializeComponent();
            this.Load += new EventHandler(Tanggal_Load);
        }

        void Tanggal_Load(object sender, EventArgs e)
        {
            _BindTanggal();
        }


        public string getTanggal
        {
            get { return _TxtTanggal.Text; }
            set { _TxtTanggal.Text = value; }
        }

        public string getBulan
        {
            get { return _TxtBulan.Text; }
            set { _TxtBulan.Text = value; }
        }

        public string getTahun
        {
            get { return _TxtTahun.Text; }
            set { _TxtTahun.Text = value; }

        }

       

        public DateTime  _GetDate()
        {
            DateTime MyDateTime;
            //=new DateTime(Convert.ToInt16(getTahun),Convert.ToInt16(getBulan),Convert.ToInt16(getTanggal));
            try
            {
                if (Validasi())
                {
                    //String MyString;
                    //MyString = getTanggal + "-" + getBulan + "-" + getTahun + " 00:00:00";
                    //MyString = "1999-09-01 21:34 p.m.";  //Depends on your regional settings
                    MyDateTime = new DateTime(Convert.ToInt16(getTahun), Convert.ToInt16(getBulan), Convert.ToInt16(getTanggal));
                   
                    //MyDateTime = new DateTime();
                    //MyDateTime = DateTime.ParseExact(MyString, "yyyy-MM-dd HH:mm:tt",
                    //                                 null);
                    return MyDateTime;
                }
            }
            catch (Exception)
            {
                throw;
            }


            return new DateTime();
        }

        public void  _SetDate(string _DateFormat)
        {
            DateTime _time = DateTime.Parse(_DateFormat);
            _TxtTanggal.Text = _time.ToString("dd");
            _TxtBulan.Text = _time.ToString("MM");
            _TxtTahun.Text = _time.ToString("yyyy");
        }

        void _BindTanggal()
        {
            for(int _Tgl=1;_Tgl < 32;_Tgl++)
            {
                _TxtTanggal.Items.Add(_Tgl.ToString());
            }

            for (int _Bln=1;_Bln<13;_Bln++)
            {
                _TxtBulan.Items.Add(_Bln.ToString());
            }

            for  (int _Tahun=1941; _Tahun < 2030;_Tahun++)
            {
                _TxtTahun.Items.Add(_Tahun++);
            }

        }

       public  bool  Validasi()
        {
            if (string.IsNullOrEmpty(_TxtTanggal.Text))
                return false;

            if(string.IsNullOrEmpty(_TxtBulan.Text))
                return false;

            if(string.IsNullOrEmpty(_TxtTahun.Text))
                return false;

            return true;
        }
       


    }
}
