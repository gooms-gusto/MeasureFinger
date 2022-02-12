using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Hitungan
{
   public class PotensialSkill:IPotentisialSkill
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalClass _global = new GlobalClass();


        public double GetVisualTeknik(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "R", "5")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetVisualSeni(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "L", "5")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetBahasa(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "R", "4")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetMusik(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "L", "4")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetTeknikGerakan(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "R", "3")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetSeniGerakan(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "L", "3")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetLogikaMatematika(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "R", "2")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetIntuisiDanKreatifitas(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "L", "2")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetTataKepribadian(string KodePasien)
        {
            try
            {
                double _result = ((90 - _global._GetValue(KodePasien, "R", "1")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetHubunganSosial(string KodePasien)
        {
            try
            {
                double _result =  ((90 - _global._GetValue(KodePasien, "L", "1")) / _global.TotalKiriPotensialskill(KodePasien)) * 100;
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
