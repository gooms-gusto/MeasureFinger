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
namespace DAL
{
   public  class Pasien:IPasien
   {
       private StringBuilder _sql = new StringBuilder();
       private SQLiteConnection SqlCnn;
       
      
       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       public static SQLiteConnection _cnnConnection()
       {
          
           string dbPath = Mpath.SetPathStartup;
           return new SQLiteConnection(@"Data Source=" + dbPath + "\\fing.db");
       }

       public Pasien()
       {
           try
           {
               SqlCnn = _cnnConnection();
               SqlCnn.Open();

           }
           catch (Exception ex)
           {
               log.Error("Error",ex);
           }
       }

       public string _GenerateKodeID()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(
                   " SELECT NUM_ID_CNTR FROM TB_NUM_ID ");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();

               SQLiteCommand _cm=new SQLiteCommand(_sql.ToString(),SqlCnn);
               string Kode = "PSN" + _cm.ExecuteScalar().ToString();
               _sql.Length = 0;
               if (string.IsNullOrEmpty(Kode))
                   return "";
               return Kode;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return "";
       }

       public string _GetIncrementKode()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(
                   " SELECT NUM_ID_CNTR FROM `TB_NUM_ID` ");

               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();

               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               string Kode = _cm.ExecuteScalar().ToString();
               _sql.Length = 0;
               if (string.IsNullOrEmpty(Kode))
                   return "";
               return Kode;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return "";
       }

       public void _UpdateKodePasien()
       {
         try
         {
             _sql.Length = 0;
             _sql.Append(
                 "UPDATE TB_NUM_ID SET NUM_ID_CNTR='" + (Convert.ToInt32(_GetIncrementKode()) + 1) + "'");


             if (SqlCnn.State == ConnectionState.Closed)
                 SqlCnn.Open();
             SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
             int _insert_record =_cm.ExecuteNonQuery();
         }
         catch (Exception ex)
         {
             log.Error("Error", ex);
         }
       }

       public void _InsertIDUkurFinger()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" INSERT INTO TB_UKUR_SIDIK (ID_PASIEN) VALUES ('" + _GenerateKodeID() + "')");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
       }

       public void _InsertDominasiOtak()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" INSERT INTO TB_DOMINASI_OTAK (ID_PASIEN) VALUES ('" + _GenerateKodeID() + "')");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
       }

       public void _InsertGayaBelajar()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" INSERT INTO TB_GAYA_BELAJAR (ID_PASIEN) VALUES ('" + _GenerateKodeID() + "')");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
       }

       public void _InsertKecenderunganOtak()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" INSERT INTO TB_KECENDERUNGAN_OTAK (ID_PASIEN) VALUES ('" + _GenerateKodeID() + "')");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
       }

       public void _InsertGayaKerja()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" INSERT INTO TB_GAYA_KERJA(ID_PASIEN) VALUES ('" + _GenerateKodeID() + "')");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
       }

       public void _InsertKecenderunganBakat()
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" INSERT INTO TB_KECENDERUNGAN_BAKAT(ID_PASIEN) VALUES ('" + _GenerateKodeID() + "')");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
       }





       public bool _SimpanPasien(string NamaPasien, string UmurPasien, System.DateTime _tanggal_analisa,
       string l1, string l2, string l3, string l4, string l5, string r1, string r2, string r3, string r4, string r5)
       {
         try
         {
                _sql.Length = 0;
                _sql.Append(string.Format(
                    " INSERT INTO TB_PASIEN (ID_PASIEN, TANGGAL_ANALISA, NAMA_PASI" +
                    "EN, USIA,L1,L2,L3,L4,L5,R1,R2,R3,R4,R5) VALUES ('" +
                    _GenerateKodeID() + "','" + _tanggal_analisa.ToString("yyyy-MM-dd hh:mm:ss") +
                    "','" + NamaPasien + "','" + UmurPasien + "','{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", l1, l2, l3, l4, l5, r1, r2, r3, r4, r5));
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                if (_insert_record > 0)
                {
                    _InsertIDUkurFinger();
                    _InsertDominasiOtak();
                    _InsertGayaKerja();
                    _InsertGayaBelajar();
                    _InsertKecenderunganBakat();
                    _InsertKecenderunganOtak();
                    _UpdateKodePasien();
                    return true;
                }
          }
         catch (Exception ex)
         {
             log.Error("Error", ex);
         }
          return false;
       }

       public string _GetKodePasien()
       {
            return _GenerateKodeID();
       }

       public DataTable _SelectPasien(string KodePasien, string NamaPasien)
       {
         try
            {
                _sql.Length = 0;
                _sql.Append(
                    " SELECT * FROM tb_pasien ");
                
                if (!string.IsNullOrEmpty(KodePasien))
                    _sql.Append(" WHERE UPPER(ID_PASIEN)='" + KodePasien.ToUpper() + "' ");

                if (!string.IsNullOrEmpty(NamaPasien)) 
                    _sql.Append(" WHERE UPPER(NAMA_PASIEN) like '" + NamaPasien.ToUpper() + "%' ");

                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da=new SQLiteDataAdapter(_cm );
                DataSet _ds = new DataSet();
                _da.Fill(_ds);

                return _ds.Tables[0];

            }
         catch (Exception ex)
         {
             log.Error("Error", ex);
         }
         return null;
        }




        public bool _UpdatePasien(string KodePasien, string NamaPasien, string UmurPasien, DateTime _tanggal_analisa, string l1, string l2, string l3, string l4, string l5, string r1, string r2, string r3, string r4, string r5)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(
                    " UPDATE TB_PASIEN SET NAMA_PASIEN='" + NamaPasien + "',");
                _sql.Append(" USIA='" + UmurPasien + "',");
                _sql.Append(" TANGGAL_ANALISA='" + _tanggal_analisa.ToString("yyyy-MM-dd hh:mm:ss") + "',");
                _sql.Append(" L1='" + l1 + "',");
                _sql.Append(" L2='" + l2 + "',");
                _sql.Append(" L3='" + l3 + "',");
                _sql.Append(" L4='" + l4 + "',");
                _sql.Append(" L5='" + l5 + "',");
                _sql.Append(" R1='" + r1 + "',");
                _sql.Append(" R2='" + r2 + "',");
                _sql.Append(" R3='" + r3 + "',");
                _sql.Append(" R5='" + r5 + "' ");
                _sql.Append(" WHERE ID_PASIEN='" + KodePasien + "'");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();

                if (_insert_record > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return false;
        }



        public bool _DeletePasien(string KodePasien)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" DELETE FROM TB_PASIEN WHERE ID_PASIEN='" + KodePasien + "'");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                if (_insert_record > 0)
                {
                    _DeleteDataUkur(KodePasien);
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }

            return false;

        }

       bool _DeleteDataUkur(string KodePasien)
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" DELETE FROM TB_UKUR_SIDIK WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();

               _sql.Length = 0;
               _sql.Append(" DELETE FROM TB_DOMINASI_OTAK WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
              _insert_record = _cm.ExecuteNonQuery();

               _sql.Length = 0;
               _sql.Append(" DELETE FROM TB_GAYA_BELAJAR WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               _insert_record = _cm.ExecuteNonQuery();

               _sql.Length = 0;
               _sql.Append(" DELETE FROM TB_GAYA_KERJA WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               _insert_record = _cm.ExecuteNonQuery();

               _sql.Length = 0;
               _sql.Append(" DELETE FROM TB_KECENDERUNGAN_OTAK WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               _insert_record = _cm.ExecuteNonQuery();

               _sql.Length = 0;
               _sql.Append(" DELETE FROM TB_KECENDERUNGAN_BAKAT WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               _insert_record = _cm.ExecuteNonQuery();

             


               return true;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return false;
       }


       public bool _UpdateSidikJari(string KodePasien, string NamaKolom, string  value)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" UPDATE TB_UKUR_SIDIK SET " + NamaKolom + "=" + value+ " WHERE ID_PASIEN='" + KodePasien + "'");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }

            return false;
        }





        public DataTable _SelectDataUkur(string KodePasien)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(
                    " SELECT L1,L2,L3,L4,L5,R1,R2,R3,R4,R5 FROM TB_UKUR_SIDIK WHERE ID_PASIEN='" + KodePasien +"'");


                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);

                return _ds.Tables[0];


            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return null;
        }

        public DataTable _SelectR(string KodePasien)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(
                    " SELECT R1,R2,R3,R4,R5 FROM TB_UKUR_SIDIK WHERE ID_PASIEN='" + KodePasien + "'");


                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);

                return _ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return null;
        }

        public DataTable _SelectL(string KodePasien)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(
                    " SELECT L1,L2,L3,L4,L5 FROM TB_UKUR_SIDIK WHERE ID_PASIEN='" + KodePasien + "'");


                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);

                return _ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return null;
        }





        public DataSet _SelectHasilAnalisa(string KodePasien)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(
                    "SELECT  A.ID_PASIEN, E.NAMA_PASIEN,E.TANGGAL_ANALISA,A.OTAK_KIRI, A.OTAK_KANAN, B.VISUAL_TEKS, B.VISUAL_GAMBAR, B.AUDITORI_BAHASA, B.AUDITORI_MUSIK, B.KINESTATIK_GERAKAN, B.KINESTATIK_SENTUHAN, C.PENGAMATAN_DAN_TRENDSETTER,C.KOMUNIKATOR, C.EKSEKUTOR, C.INISIATOR_DAN_PEMIMPIN, C.PENGONSEP_DAN_PENGELOLA, D.VISUAL_TEKNIK, D.VISUAL_SENI, D.BAHASA, D.MUSIK, D.TEKNIK_GERAKAN, D.SENI_GERAKAN, D.LOGIKA_MATEMATIKA, D.INTUISI_DAN_KREATIVITAS, D.TATA_KEPRIBADIAN, D.TATA_HUBUNGAN_SOSIAL,F.BRAIN_STEM,F.LIMBIC_SYSTEM,F.NEO_CORTEX,E.ID_PASIEN_ALIAS,E.USIA ");
                _sql.Append(
                    " FROM TB_DOMINASI_OTAK AS A, TB_GAYA_BELAJAR AS B, TB_GAYA_KERJA AS C, TB_KECENDERUNGAN_BAKAT AS D, TB_PASIEN AS E , TB_KECENDERUNGAN_OTAK AS F");
                _sql.Append(
                    " WHERE (((A.ID_PASIEN)=[B].[ID_PASIEN] And (A.ID_PASIEN)=[C].[ID_PASIEN] And (A.ID_PASIEN)=[D].[ID_PASIEN]) and (A.ID_PASIEN=[E].[ID_PASIEN])) AND A.ID_PASIEN=F.ID_PASIEN AND A.ID_PASIEN='" + KodePasien + "'");

                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();

                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
                DataSet _ds = new DataSet();
                _da.Fill(_ds);

                return _ds;
            }
            catch (Exception)
            {

            }
            return null;
        }




        public bool _UpdateDominasiOtak(string KodePasien, double OtakKiri, double OtakKanan)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" UPDATE TB_DOMINASI_OTAK SET OTAK_KIRI='" + OtakKiri + "',OTAK_KANAN='" + OtakKanan + "' WHERE ID_PASIEN='" + KodePasien + "'");
               

                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool _UpdateGayaBelajar(string KodePasien, double VisualTeks, double VisualGambar, double AuditoriBahasa, double AuditoriMusik, double KinestatikGerakan, double KinestatikSentuhan)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" UPDATE TB_GAYA_BELAJAR SET VISUAL_TEKS='" + VisualTeks +"',VISUAL_GAMBAR='" +VisualGambar + "',AUDITORI_BAHASA='"+ AuditoriBahasa +"',AUDITORI_MUSIK='" + AuditoriMusik +"',KINESTATIK_GERAKAN='" + KinestatikGerakan +"',KINESTATIK_SENTUHAN='" + KinestatikSentuhan +"' WHERE ID_PASIEN='" + KodePasien + "'");

                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool _UpdateGayaKerja(string KodePasien, double PengamatanDanTrendsetter, double Komunikator,double Eksekutor, double InisiatorDanPemimpin, double PengonsepDanPengelola)
        {
            try
            {
                _sql.Length = 0;
                _sql.Append(" UPDATE TB_GAYA_KERJA SET PENGAMATAN_DAN_TRENDSETTER='"+ PengamatanDanTrendsetter + "',KOMUNIKATOR='" + Komunikator + "',EKSEKUTOR='"+ Eksekutor +"',INISIATOR_DAN_PEMIMPIN='"+ InisiatorDanPemimpin + "',PENGONSEP_DAN_PENGELOLA='"+PengonsepDanPengelola + "' WHERE ID_PASIEN='" + KodePasien + "'");
                if (SqlCnn.State == ConnectionState.Closed)
                    SqlCnn.Open();
                SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                int _insert_record = _cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

       public bool _UpdateKecenderunganBakat(string KodePasien, double VisualTeknik, double VisualSeni, double Bahasa, double Musik, double TeknikGerakan, double SeniGerakan, double LogikaMatematika, double IntuisiDanKreativitas, double TataKepribadian, double TataHubunganSosial)
        {
                try
                {
                    _sql.Length = 0;
                    _sql.Append(" UPDATE TB_KECENDERUNGAN_BAKAT SET VISUAL_TEKNIK=" + VisualTeknik + " ,VISUAL_SENI=" +
                                VisualSeni + ",BAHASA=" + Bahasa + " ,MUSIK=" + Musik + " ,TEKNIK_GERAKAN=" +
                                TeknikGerakan + ",SENI_GERAKAN=" + SeniGerakan + ",LOGIKA_MATEMATIKA=" + LogikaMatematika +
                                ",INTUISI_DAN_KREATIVITAS ="+ IntuisiDanKreativitas +
                                ",TATA_KEPRIBADIAN=" +TataKepribadian + ",TATA_HUBUNGAN_SOSIAL=" 
                                + TataHubunganSosial + " WHERE ID_PASIEN='" + KodePasien + "'");
                    if (SqlCnn.State == ConnectionState.Closed)
                        SqlCnn.Open();
                    SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
                    int _insert_record = _cm.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                }
                return false;
        }






       public bool _UpdateKecenderunganOtak(string KodePasien, double BrainStem, double LimbicSystem, double NeoCortex)
       {
           try
           {

               _sql.Length = 0;
               _sql.Append(" UPDATE TB_KECENDERUNGAN_OTAK SET BRAIN_STEM='" + BrainStem + "',LIMBIC_SYSTEM='"+ LimbicSystem + "',NEO_CORTEX='" + NeoCortex + "' WHERE ID_PASIEN='" + KodePasien + "'");
               
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
               return true;

           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }

           return false;
       }


       public System.Data.DataTable _SelectKencederunganOtak(string KodePasien)
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(
                   " SELECT BRAIN_STEM,LIMBIC_SYSTEM,NEO_CORTEX FROM TB_KECENDERUNGAN_OTAK WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();

               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
               DataSet _ds = new DataSet();
               _da.Fill(_ds);
               return _ds.Tables[0];
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return null;
       }


       public bool _UpdateIDAlias(string KodePasien, string KodePasienAlias)
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(" UPDATE TB_PASIEN SET ID_PASIEN_ALIAS='" + KodePasienAlias + "' WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();
               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               int _insert_record = _cm.ExecuteNonQuery();
               return true;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return false;
       }





       public string _SelectIDAlias(string KodePasien)
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(
                   " SELECT ID_PASIEN_ALIAS FROM TB_PASIEN WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();

               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               string ID_Alias = _cm.ExecuteScalar().ToString();
             
               return ID_Alias;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return null;
       }


       public bool _ValidasiUkur(string KodePasien)
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(
                   " SELECT r1,r2,r3,r4,r5,l1,l2,l3,l4,l5 FROM TB_UKUR_SIDIK WHERE ID_PASIEN='" + KodePasien + "'");

               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();

               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
               DataSet _ds = new DataSet();
               _da.Fill(_ds);

               DataTable _dataTable = _ds.Tables[0];
               if (_dataTable.Rows.Count> 0)
               {
                   if (string.IsNullOrEmpty(_dataTable.Rows[0]["R1"].ToString()) || string.IsNullOrEmpty(_dataTable.Rows[0]["R2"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["R3"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["R4"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["R5"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["L1"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["L2"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["L3"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["L4"].ToString()) ||string.IsNullOrEmpty(_dataTable.Rows[0]["L5"].ToString()))
                   {
                       return false;
                   }
               }
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return true;
       }


       public bool _ValidasiIDPasien(string KodePasien)
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(
                   " SELECT ID_PASIEN_ALIAS FROM TB_PASIEN WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();

               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
               DataSet _ds = new DataSet();
               _da.Fill(_ds);

               DataTable _dataTable = _ds.Tables[0];
               if (_dataTable.Rows.Count > 0)
               {
                   if (!string.IsNullOrEmpty(_dataTable.Rows[0]["ID_PASIEN_ALIAS"].ToString()))
                   {
                       return true;
                   }
               }


           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return false;
       }

       public bool _ValidasiCortexPasien(string KodePasien)
       {
           try
           {
               _sql.Length = 0;
               _sql.Append(
                   " SELECT BRAIN_STEM,LIMBIC_SYSTEM,NEO_CORTEX FROM TB_KECENDERUNGAN_OTAK WHERE ID_PASIEN='" + KodePasien + "'");
               if (SqlCnn.State == ConnectionState.Closed)
                   SqlCnn.Open();

               SQLiteCommand _cm = new SQLiteCommand(_sql.ToString(), SqlCnn);
               SQLiteDataAdapter _da = new SQLiteDataAdapter(_cm);
               DataSet _ds = new DataSet();
               _da.Fill(_ds);

               DataTable _dataTable= _ds.Tables[0];
               if (_dataTable.Rows.Count > 0)
               {
                   if (string.IsNullOrEmpty(_dataTable.Rows[0]["BRAIN_STEM"].ToString()) && string.IsNullOrEmpty(_dataTable.Rows[0]["LIMBIC_SYSTEM"].ToString()) && string.IsNullOrEmpty(_dataTable.Rows[0]["NEO_CORTEX"].ToString()))
                   {
                       return false;
                   }
               }
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return true;
       }
   }
}
