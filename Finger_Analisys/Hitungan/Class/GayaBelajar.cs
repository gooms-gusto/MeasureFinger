﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Hitungan
{
   public  class GayaBelajar:IGayaBelajar
    {

       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       private GlobalClass _global = new GlobalClass();

        public double GetVisualTeks(string KodePasien)
        {
            try
            {
                double _result =((90-_global._GetValue(KodePasien, "R", "5"))/_global.TotalKiriGayaBelajar(KodePasien))*100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetVisualGambar(string KodePasien)
        {
            try
            {
                double _result =  ((90-_global._GetValue(KodePasien, "L", "5")) / _global.TotalKiriGayaBelajar(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetAuditoriBahasa(string KodePasien)
        {
            try
            {
                double _result =  ((90-_global._GetValue(KodePasien, "R", "4")) / _global.TotalKiriGayaBelajar(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetAuditoriMusik(string KodePasien)
        {
            try
            {
                double _result =  ((90-_global._GetValue(KodePasien, "L", "4")) / _global.TotalKiriGayaBelajar(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetKinestatikGerakan(string KodePasien)
        {
            try
            {
                double _result = ((90-_global._GetValue(KodePasien, "R", "3")) / _global.TotalKiriGayaBelajar(KodePasien)) * 100;
                return _result;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return 0;
        }

        public double GetKinestatikSentuhan(string KodePasien)
        {
            try
            {
                double _result = ((90-_global._GetValue(KodePasien, "L", "3")) / _global.TotalKiriGayaBelajar(KodePasien)) * 100;
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