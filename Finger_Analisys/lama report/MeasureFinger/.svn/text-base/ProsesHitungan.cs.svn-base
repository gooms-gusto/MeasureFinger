using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MeasureFinger
{
   public class ProsesHitungan
   {
       private Proxy _proxy = new Proxy();
       private DataTable _Data;
       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       //public DataTable _GetL(string _KodePasien)
       //{
       //    try
       //    {
       //         return _proxy._GetPasien()._SelectL(_KodePasien);
       //    }
       //    catch (Exception)
       //    {
       //    }
       //    return null;
       //}

       //public DataTable _GetR(string _KodePasien)
       //{
       //    try
       //    {
       //        return _proxy._GetPasien()._SelectR(_KodePasien);
       //    }
       //    catch (Exception)
       //    {
       //    }
       //    return null;

       //}


       public double  _GetValue(string KodePasien, string jari,string nomor)
       {
           try
           {
               DataTable _dataTable = null;
               if (jari == "R")
                   return Convert.ToDouble(_proxy._GetPasien()._SelectR(KodePasien).Rows[0][jari + nomor]);
               else if (jari=="L")
                   return Convert.ToDouble(_proxy._GetPasien()._SelectL(KodePasien).Rows[0][jari + nomor]);
           }
           catch (Exception ex)
           {
               
               log.Error("Error", ex);
           }
           return 0;
       }

       public double  _GetSum_R(string KodePasien)
       {
           double _sumr=0;
           _Data = _proxy._GetPasien()._SelectR(KodePasien);

           try
           {
               for (int _rowputar=0;_rowputar < _Data.Columns.Count;_rowputar++)
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
           double _suml=0;
           _Data = _proxy._GetPasien()._SelectL(KodePasien);

           try
           {
               for (int _rowputar = 0; _rowputar < _Data.Columns.Count; _rowputar++)
               {
                   _suml += System.DBNull.Value==_Data.Rows[0]["l" + (_rowputar + 1)]? 0:Convert.ToDouble(_Data.Rows[0]["l" + (_rowputar + 1).ToString()]);
               }
               return _suml;
           }
           catch (Exception ex)
           {

               log.Error("Error", ex);
           }
           return 0;


       }

       #region OtakKiriKanan
       public double _HitungProsentaseOtakKiri(string _KodePasien)
       {
           try
           {

               double _SumKananKiri = _GetSum_L(_KodePasien) + _GetSum_R(_KodePasien);
               double _prosentase = (_GetSum_R(_KodePasien)/_SumKananKiri)*100;
               return Math.Round(_prosentase, 2);
           }
           catch (Exception)
           {

           }
           return 0;
       }

       public double _HitungProsentaseOtakKanan(string _KodePasien)
       {
           try
           {

               double _SumKananKiri = _GetSum_L(_KodePasien) + _GetSum_R(_KodePasien);
               double _prosentase = (_GetSum_L(_KodePasien) / _SumKananKiri) * 100;
               return Math.Round(_prosentase, 2);
           }
           catch (Exception)
           {
                
           }
           return 0;
       }
       #endregion
       
       #region GayaBelajar
       public double _HitungProsentaseVisualTeks(string _KodePasien)
       {
            try
            {
                double result = Math.Round((_GetValue(_KodePasien, "R", "5")/60)*20,2);
                return result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
       }

       public double _HitungProsentaseVisualGambar(string _KodePasien)
       {
           try
           {
               double result = Math.Round((_GetValue(_KodePasien, "L", "5") / 60) * 20, 2);
               return result;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }

       public double _HitungProsentaseAuditoriBahasa(string _KodePasien)
       {
           try
           {
               double result = Math.Round((_GetValue(_KodePasien, "R", "4") / 60) * 20, 2);
               return result;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }

       public double _HitungProsentaseAuditoriMusik(string _KodePasien)
       {
           try
           {
               double result = Math.Round((_GetValue(_KodePasien, "L", "4") / 60) * 20, 2);
               return result;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }

       public double _HitungProsentaseKinestikGerakan(string _KodePasien)
       {
           try
           {
               double result = Math.Round((_GetValue(_KodePasien, "R", "3") / 60) * 20, 2);
               return result;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }

       public double _HitungProsentaseKinestikSentuhan(string _KodePasien)
       {
           try
           {
               double result = Math.Round((_GetValue(_KodePasien, "L", "3") / 60) * 20, 2);
               return result;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }

       #endregion

       #region GayaKerja


       public double _HitungProsentasePengamatan(string _KodePasien)
       {
           try
           {
               double result =Math.Round((60 - (_GetValue(_KodePasien, "R", "5") + _GetValue(_KodePasien, "L", "5")) /2)/60 * 20,2);
               return result;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }


       public double _HitungProsentaseKomunikator(string _KodePasien)
       {
           try
           {
               double result = Math.Round((60 - (_GetValue(_KodePasien, "R", "4") + _GetValue(_KodePasien, "L", "4")) / 2) / 60 * 20, 2);
               return result;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return 0;
       }


       #endregion


   }
}
