using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DAL
{

    public interface IProxy
    {
        IPasien _GetPasien();
        ILisensi _GetLic();
        ILogin _GetLogin();
        IProcessor _GetProcessor();
        IPerangkatKeras _GetHardware();
        ILimit _GetLimit();

    }

    public interface ILimit
    {
        bool _Expired();
        bool _UpdateCount();
        bool _AktifLimit();
    }


    public interface IProcessor
    {
        string _GetIDProcessor();

    }

    public interface IPerangkatKeras
    {
        string _GetIDProcessor();
        string _GetBios();
        string _GetDiskID();
        string _GetBaseID();
        string _GetVideoID();
        string _GetMacID();
        string _GetValue();
        string _GetNomerSeri();
    }

    public interface ILogin
    {
        bool _UbahPassword(string Pwd);
        bool _ValidateLogin(string Pwd);
    }


    public interface ILisensi
    {
        string _GetLisensi();
        bool _CekLisensi();
        bool _RegisterLisensi(string key, string company);
        bool _HapusLisensi();
        string _GetCompany();
    }

    public interface IPasien
    {
        bool _SimpanPasien(string NamaPasien, string UmurPasien, System.DateTime _tanggal_analisa, string l1, string l2,
                           string l3, string l4, string l5
                           , string r1, string r2, string r3, string r4, string r5);

        bool _UpdatePasien(string KodePasien, string NamaPasien, string UmurPasien, System.DateTime _tanggal_analisa,
                           string l1, string l2, string l3, string l4, string l5
                           , string r1, string r2, string r3, string r4, string r5);

        bool _DeletePasien(string KodePasien);

        string _GetKodePasien();

        System.Data.DataTable _SelectPasien(string KodePasien, string NamaPasien);

        bool _UpdateSidikJari(string KodePasien, string NamaKolom, string value);

        bool _UpdateDominasiOtak(string KodePasien, double OtakKiri, double OtakKanan);

        bool _UpdateGayaBelajar(string KodePasien, double VisualTeks, double VisualGambar, double AuditoriBahasa,
                                double AuditoriMusik, double KinestatikGerakan, double KinestatikSentuhan);

        bool _UpdateGayaKerja(string KodePasien, double PengamatanDanTrendsetter, double Komunikator, double Eksekutor,
                              double InisiatorDanPemimpin, double PengonsepDanPengelola);

        bool _UpdateKecenderunganBakat(string KodePasien, double VisualTeknik, double VisualSeni, double Bahasa,
                                       double Musik, double TeknikGerakan, double SeniGerakan, double LogikaMatematika,
                                       double IntuisiDanKreativitas, double TataKepribadian, double TataHubunganSosial);

        System.Data.DataTable _SelectDataUkur(string KodePasien);

        System.Data.DataTable _SelectR(string KodePasien);

        System.Data.DataTable _SelectL(string KodePasien);

        System.Data.DataSet _SelectHasilAnalisa(string KodePasien);

        bool _UpdateKecenderunganOtak(string KodePasien, double BrainStem, double LimbicSystem, double NeoCortex);

        System.Data.DataTable _SelectKencederunganOtak(string KodePasien);

        bool _UpdateIDAlias(string KodePasien, string KodePasienAlias);

        string _SelectIDAlias(string KodePasien);

        bool _ValidasiUkur(string KodePasien);

        bool _ValidasiIDPasien(string KodePasien);

        bool _ValidasiCortexPasien(string KodePasien);

       

    }
}
