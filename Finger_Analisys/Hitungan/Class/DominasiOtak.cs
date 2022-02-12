using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using DAL;
namespace Hitungan
{
   public class DominasiOtak:IDominasiOtak
    {

        private Proxy _proxy = new Proxy();
        private DataTable _Data;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalClass _global = new GlobalClass();


        public double GetOtakKanan(string KodePasien)
        {
            try
            {


                double _SumKananKiri = _global._GetSum_L(KodePasien) + _global._GetSum_R(KodePasien);
                double _prosentase = (_global._GetSum_L(KodePasien) / _SumKananKiri) * 100;
                return Math.Round(_prosentase, 3);

            }
            catch (Exception ex)
            { 
                log.Error("Error", ex);
            }

            return 0;
        }

        public double GetOtakKiri(string KodePasien)
        {
            try
            {
                double _SumKananKiri = _global._GetSum_L(KodePasien) + _global._GetSum_R(KodePasien);
                double _prosentase = (_global._GetSum_R(KodePasien) / _SumKananKiri) * 100;
                return Math.Round(_prosentase, 3);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }
    }
}
