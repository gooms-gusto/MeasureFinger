using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hitungan
{
    public interface IHitung
    {
        IDominasiOtak GetDominasiOtak();
        IGayaBelajar GetGayaBelajar();
        IGayaKerja GetGayaKerja();
        IPotentisialSkill GetPotentisialSkill();
    }

    public interface IDominasiOtak
    {
        double GetOtakKanan(string @KodePasien);
        double GetOtakKiri(string @KodePasien);
    }

    public interface IGayaBelajar
    {

        double GetVisualTeks(string @KodePasien);
        double GetVisualGambar(string @KodePasien);
        double GetAuditoriBahasa(string @KodePasien);
        double GetAuditoriMusik(string @KodePasien);
        double GetKinestatikGerakan(string @KodePasien);
        double GetKinestatikSentuhan(string @KodePasien);
    }

    public interface IGayaKerja
    {
        double GetPengamatan(string @KodePasien);
        double GetKomunikator(string @KodePasien);
        double GetEksekutorDanPelaksana(string @KodePasien);
        double GetInisiatorDanPemimpin(string @KodePasien);
        double GetPengonsepDanPengelola(string @KodePasien);
    }

    public interface IPotentisialSkill
    {
        double GetVisualTeknik(string @KodePasien);
        double GetVisualSeni(string @KodePasien);
        double GetBahasa(string @KodePasien);
        double GetMusik(string @KodePasien);
        double GetTeknikGerakan(string @KodePasien);
        double GetSeniGerakan(string @KodePasien);
        double GetLogikaMatematika(string @KodePasien);
        double GetIntuisiDanKreatifitas(string @KodePasien);
        double GetTataKepribadian(string @KodePasien);
        double GetHubunganSosial(string @KodePasien);
       
    }
}
