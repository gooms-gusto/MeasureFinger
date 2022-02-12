using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using log4net;
using System.Data;
namespace Hitungan
{
    public class GlobalClass
    {
        private Proxy _proxy = new Proxy();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public double _GetValue(string KodePasien, string jari, string nomor)
        {
            try
            {
                DataTable _dataTable = null;
                if (jari == "R")
                    return Convert.ToDouble(_proxy._GetPasien()._SelectR(KodePasien).Rows[0][jari + nomor]);
                else if (jari == "L")
                    return Convert.ToDouble(_proxy._GetPasien()._SelectL(KodePasien).Rows[0][jari + nomor]);
            }
            catch (Exception ex)
            {

                log.Error("Error", ex);
            }
            return 0;
        }

        public double _GetSum_R(string KodePasien)
        {
            double _sumr = 0;
            DataTable _Data = _proxy._GetPasien()._SelectR(KodePasien);

            try
            {
                for (int _rowputar = 0; _rowputar < _Data.Columns.Count; _rowputar++)
                {
                    _sumr += System.DBNull.Value == _Data.Rows[0]["r" + (_rowputar + 1)] ? 0 : Convert.ToDouble(_Data.Rows[0]["r" + (_rowputar + 1).ToString()]);
                }
                return _sumr;
            }
            catch (Exception ex)
            {

                log.Error("Error", ex);
            }
            return 0;
        }

        public double _GetSum_L(string KodePasien)
        {
            double _suml = 0;
            DataTable _Data = _proxy._GetPasien()._SelectL(KodePasien);

            try
            {
                for (int _rowputar = 0; _rowputar < _Data.Columns.Count; _rowputar++)
                {
                    _suml += System.DBNull.Value == _Data.Rows[0]["l" + (_rowputar + 1)] ? 0 : Convert.ToDouble(_Data.Rows[0]["l" + (_rowputar + 1).ToString()]);
                }
                return _suml;
            }
            catch (Exception ex)
            {

                log.Error("Error", ex);
            }
            return 0;
        }

        public double TotalKiriGayaBelajar( string KodePasien)
        {
            double _sum_gaya_belajar = 0;
            DataTable jari_kiri = _proxy._GetPasien()._SelectL(KodePasien);
            DataTable jari_kanan = _proxy._GetPasien()._SelectR(KodePasien);
            try
            {
                for (int _rowputarkiri = 0; _rowputarkiri < jari_kiri.Columns.Count; _rowputarkiri++)
                {
                    if (jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L5" || jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L4" || jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L3")
                        _sum_gaya_belajar += 90-(System.DBNull.Value == jari_kiri.Rows[0]["l" + (_rowputarkiri + 1)] ? 0 : Convert.ToDouble(jari_kiri.Rows[0]["l" + (_rowputarkiri + 1).ToString()]));
                }

                for (int _rowputarkanan = 0; _rowputarkanan < jari_kanan.Columns.Count; _rowputarkanan++)
                {
                    if (jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R5" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R4" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R3")
                        _sum_gaya_belajar +=90-( System.DBNull.Value == jari_kanan.Rows[0]["r" + (_rowputarkanan + 1)] ? 0 : Convert.ToDouble(jari_kanan.Rows[0]["r" + (_rowputarkanan + 1).ToString()]));
                }
               
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            } 
            return _sum_gaya_belajar;
        }


       public double  TotalKiriGayaKerja(string KodePasien)
       {
           try
           {
               double _sum_gaya_kerja = 0;
               DataTable jari_kiri = _proxy._GetPasien()._SelectL(KodePasien);
               DataTable jari_kanan = _proxy._GetPasien()._SelectR(KodePasien);

               for (int _rowputarkanan = 0; _rowputarkanan < jari_kanan.Columns.Count; _rowputarkanan++)
               {
                   if (jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R1" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R2" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R3" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R4" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R5")
                       _sum_gaya_kerja += 90 - (((System.DBNull.Value == jari_kanan.Rows[0]["r" + (_rowputarkanan + 1)] ? 0 : Convert.ToDouble(jari_kanan.Rows[0]["r" + (_rowputarkanan + 1).ToString()])) + (System.DBNull.Value == jari_kiri.Rows[0]["l" + (_rowputarkanan + 1)] ? 0 : Convert.ToDouble(jari_kiri.Rows[0]["l" + (_rowputarkanan + 1).ToString()]))) / 2);
               }

               return _sum_gaya_kerja;

           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }

        public double TotalKiriPotensialskill(string KodePasien)
        {
            double _sum_potensial_skill = 0;
            DataTable jari_kiri = _proxy._GetPasien()._SelectL(KodePasien);
            DataTable jari_kanan = _proxy._GetPasien()._SelectR(KodePasien);
            try
            {
                for (int _rowputarkiri = 0; _rowputarkiri < jari_kiri.Columns.Count; _rowputarkiri++)
                {
                    if (jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L1" || jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L2" || jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L3" || jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L4" || jari_kiri.Columns[_rowputarkiri].ColumnName.ToUpper().Trim() == "L5")
                        _sum_potensial_skill += 90 - (System.DBNull.Value == jari_kiri.Rows[0]["l" + (_rowputarkiri + 1)] ? 0 : Convert.ToDouble(jari_kiri.Rows[0]["l" + (_rowputarkiri + 1).ToString()]));
                }

                for (int _rowputarkanan = 0; _rowputarkanan < jari_kanan.Columns.Count; _rowputarkanan++)
                {
                    if (jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R1" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R2" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R3" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R4" || jari_kanan.Columns[_rowputarkanan].ColumnName.ToUpper().Trim() == "R5")
                        _sum_potensial_skill += 90 - (System.DBNull.Value == jari_kanan.Rows[0]["r" + (_rowputarkanan + 1)] ? 0 : Convert.ToDouble(jari_kanan.Rows[0]["r" + (_rowputarkanan + 1).ToString()]));
                }

            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return _sum_potensial_skill;
        }

    }
}
