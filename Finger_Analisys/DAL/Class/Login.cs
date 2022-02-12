using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Text;
using System.IO;
using log4net;
using System.Data.SQLite;
using EncrytionHash;
namespace DAL
{
    public class Login:ILogin
    {
        
        private StringBuilder _sql = new StringBuilder();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SQLiteConnection SqlCnn;

        public static SQLiteConnection _cnnConnection()
        {
          
            string dbPath = Mpath.SetPathStartup;
            return new SQLiteConnection(@"Data Source=" + dbPath + "\\fing.db");
        }

        public Login()
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

        public bool _UbahPassword(string Pwd)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" UPDATE TB_LOGIN SET PS='" + EncrytionHash.Kunci.Encrypt( Pwd) + "'");
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

        public bool _ValidateLogin(string Pwd)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" SELECT PS FROM TB_LOGIN WHERE PS='" + EncrytionHash.Kunci.Encrypt(Pwd) + "'");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);

                if (_ds.Tables[0].Rows.Count > 0)
                   return true;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return false;
        }
    }
}
