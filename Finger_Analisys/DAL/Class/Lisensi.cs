using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Text;
using System.IO;
using log4net;
using System.Data.SQLite;
using log4net;
using EncrytionHash;
namespace DAL.Class
{
   public  class Lisensi:ILisensi
    {
        private StringBuilder _sql = new StringBuilder();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SQLiteConnection SqlCnn;

       public Lisensi()
       {
           try
           {
               SqlCnn = _cnnConnection();
               SqlCnn.Open();
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
       }


       public static SQLiteConnection _cnnConnection()
       {
         
           string dbPath = Mpath.SetPathStartup;
           return new SQLiteConnection(@"Data Source=" + dbPath + "\\fing.db");
       }

       public string _GetLisensi()
        {
            try
            {

                _sql.Length = 0;
                _sql.Append(
                    " SELECT XKEY FROM TB_LIC ");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                string key = _cm.ExecuteScalar().ToString();

                if (string.IsNullOrEmpty(key))
                    return "";

                return key;

            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }

        public bool _CekLisensi()
        {
            try
            {

                _sql.Length = 0;
                _sql.Append(
                    " SELECT KEY FROM TB_LIC ");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);

                if (_ds.Tables[0].Rows.Count < 1)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return false;
        }


        public bool _RegisterLisensi(string key, string company)
        {
            try
            {
                _HapusLisensi();

                _sql.Length = 0;
                _sql.Append(" INSERT INTO TB_LIC VALUES ('" + key+ "','" +company  +"')");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                if (_insert_record >0)
                    return true;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return false;
        }




        public bool _HapusLisensi()
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" DELETE FROM TB_LIC ");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                if (_insert_record > 0)
                    return true;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return false;
        }


        public string _GetCompany()
        {
            try
            {

                _sql.Length = 0;
                _sql.Append(
                    " SELECT COMPANY FROM TB_LIC ");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                string key = _cm.ExecuteScalar().ToString();

                if (string.IsNullOrEmpty(key))
                    return "";

                return key;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }
    }
}
