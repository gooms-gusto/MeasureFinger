using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Hitungan
{
    public class GayaKerja:IGayaKerja
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalClass _global = new GlobalClass();


        public double GetPengamatan(string KodePasien)
        {
            try
            {
                double _result = ((90 - ((_global._GetValue(KodePasien, "R", "5") + _global._GetValue(KodePasien, "L", "5")) / 2)) / _global.TotalKiriGayaKerja(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetKomunikator(string KodePasien)
        {
            try
            {
                double _result = ((90 - ((_global._GetValue(KodePasien, "R", "4") + _global._GetValue(KodePasien, "L", "4")) / 2)) / _global.TotalKiriGayaKerja(KodePasien)) * 100;

                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetEksekutorDanPelaksana(string KodePasien)
        {
            try
            {
                double _result = ((90 - ((_global._GetValue(KodePasien, "R", "3") + _global._GetValue(KodePasien, "L", "3")) / 2)) / _global.TotalKiriGayaKerja(KodePasien)) * 100;

                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetInisiatorDanPemimpin(string KodePasien)
        {
            try
            {
                double _result = ((90 - ((_global._GetValue(KodePasien, "R", "2") + _global._GetValue(KodePasien, "L", "2")) / 2)) / _global.TotalKiriGayaKerja(KodePasien)) * 100;

                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetPengonsepDanPengelola(string KodePasien)
        {
            try
            {
                double _result = ((90 - ((_global._GetValue(KodePasien, "R", "1") + _global._GetValue(KodePasien, "L", "1")) / 2))/_global.TotalKiriGayaKerja(KodePasien))*100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }
    }
}
