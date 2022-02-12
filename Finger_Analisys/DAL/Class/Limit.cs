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
using EncrytionHash;
namespace DAL.Class
{
   public class Limit:ILimit 
    {

        private StringBuilder _sql = new StringBuilder();
        private SQLiteConnection SqlCnn;


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static SQLiteConnection _cnnConnection()
        {

            string dbPath = Mpath.SetPathStartup;
            return new SQLiteConnection(@"Data Source=" + dbPath + "\\fing.db");
        }


       public Limit()
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

       public bool _Expired()
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(
                    " SELECT * FROM tb_limit_run ");
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["xlimit"].ToString().Trim() == _ds.Tables[0].Rows[0]["xrun"].ToString().Trim())
                        return true;
                    else return false;
                }
                return true;
            }
            catch (Exception)
            {
              
            }
            return true;

        }


        public bool _UpdateCount()
        {
            try
            {
                int current = 0;
                _sql.Length = 0;
                _sql.Append(
                    " SELECT * FROM TB_LIMIT_RUN ");
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);
                if (_ds.Tables[0].Rows.Count > 0)
                {
                  current=  Convert.ToInt16(EncrytionHash.Kunci.Decrypt(_ds.Tables[0].Rows[0]["xrun"].ToString()));
                }


                _sql.Length = 0;
                _sql.Append(
                    "UPDATE TB_LIMIT_RUN SET XRUN='" + EncrytionHash.Kunci.Encrypt((current +1).ToString()) + "'");


                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                 _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                if (_insert_record > 0)
                    return true;
            }
            catch (Exception)
            {

            }
            return false;
        }


        public bool _AktifLimit()
        {
            try
            {

                int current = 0;
                _sql.Length = 0;
                _sql.Append(
                    " SELECT * FROM TB_LIMIT_RUN ");
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);
                if (_ds.Tables[0].Rows.Count > 0)
                {
                    current = Convert.ToInt16(EncrytionHash.Kunci.Decrypt(_ds.Tables[0].Rows[0]["xactiv"].ToString()));
                }

                if (current == 0)
                    return false;


                return true;
            }
            catch (Exception)
            {
              
            }
            return false;
        }
    }
}
