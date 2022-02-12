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
using EncrytionHash;
using System.Management;
using System.Security.Cryptography;
namespace DAL
{
   public  class MyProcessor:IProcessor
    {
        private StringBuilder _sql = new StringBuilder();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string identifier(string wmiClass, string wmiProperty)
        {

            try
            {
                string result = "";
                System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
                System.Management.ManagementObjectCollection moc = mc.GetInstances();
                foreach (System.Management.ManagementObject mo in moc)
                {
                    //Only get the first one
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
                return result;
                }
                catch (Exception ex)
                {
                    log.Error("Error", ex);
                }
                return "";
        }
       public string _GetIDProcessor()
       {

           string cpuid="";
           try
           {

               string retVal = identifier("Win32_Processor", "UniqueId");
               if (retVal == "") 
               {
                   retVal = identifier("Win32_Processor", "ProcessorId");
                   if (retVal == "") 
                   {
                       retVal = identifier("Win32_Processor", "Name");
                       if (retVal == "") 
                       {
                           retVal = identifier("Win32_Processor", "Manufacturer");
                       }
                      
                       retVal += identifier("Win32_Processor", "MaxClockSpeed");
                   }
               }
               return retVal;
           }
           catch (Exception ex)
           {
               log.Error("Error", ex);
           }
           return "";
       }
    }
}
