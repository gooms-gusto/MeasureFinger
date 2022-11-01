﻿using System;
using System.Management;
using System.Security.Cryptography;
using System.Security;
using System.Collections;
using System.Text;
using log4net;
using EncrytionHash;
using DeviceId;

namespace DAL
{
   public class Hardware:IPerangkatKeras
    {
       private   readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


       private   string fingerPrint = string.Empty;
 
       private   string GetHash(string s)
       {
           MD5 sec = new MD5CryptoServiceProvider();
           ASCIIEncoding enc = new ASCIIEncoding();
           byte[] bt = enc.GetBytes(s);
           return GetHexString(sec.ComputeHash(bt));
       }
       private   string GetHexString(byte[] bt)
       {
           string s = string.Empty;
           for (int i = 0; i < bt.Length; i++)
           {
               byte b = bt[i];
               int n, n1, n2;
               n = (int)b;
               n1 = n & 15;
               n2 = (n >> 4) & 15;
               if (n2 > 9)
                   s += ((char)(n2 - 10 + (int)'A')).ToString();
               else
                   s += n2.ToString();
               if (n1 > 9)
                   s += ((char)(n1 - 10 + (int)'A')).ToString();
               else
                   s += n1.ToString();
               if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
           }
           return s;
       }

       //Return a hardware identifier
       private   string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
       {
           string result = "";
           System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
           System.Management.ManagementObjectCollection moc = mc.GetInstances();
           foreach (System.Management.ManagementObject mo in moc)
           {
               if (mo[wmiMustBeTrue].ToString() == "True")
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
           }
           return result;
       }
       //Return a hardware identifier
       private   string identifier(string wmiClass, string wmiProperty)
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
        public string _GetDeviceID()
        {
            try
            { string deviceId = new DeviceIdBuilder().AddMachineName().AddMacAddress().AddOsVersion().AddUserName().ToString();
            return deviceId;}
            catch(Exception ex)
            {
                log.Error(ex);
            }
            return string.Empty;
        }
        public string _GetIDProcessor()
        {
            try
            {
                //Uses first CPU identifier available in order of preference
                //Don't get all identifiers, as very time consuming
                string retVal = identifier("Win32_Processor", "UniqueId");
                if (retVal == "") //If no UniqueID, use ProcessorID
                {
                    retVal = identifier("Win32_Processor", "ProcessorId");
                    if (retVal == "") //If no ProcessorId, use Name
                    {
                        retVal = identifier("Win32_Processor", "Name");
                        if (retVal == "") //If no Name, use Manufacturer
                        {
                            retVal = identifier("Win32_Processor", "Manufacturer");
                        }
                        //Add clock speed for extra security
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

        public string _GetBios()
        {
            try
            {
                return identifier("Win32_BIOS", "Manufacturer")
           + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
           + identifier("Win32_BIOS", "IdentificationCode")
           + identifier("Win32_BIOS", "SerialNumber")
           + identifier("Win32_BIOS", "ReleaseDate")
           + identifier("Win32_BIOS", "Version");
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }

        public string _GetDiskID()
        {
            try
            {

            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }

        public string _GetBaseID()
        {
            try
            {
                return identifier("Win32_BaseBoard", "Model")
           + identifier("Win32_BaseBoard", "Manufacturer")
           + identifier("Win32_BaseBoard", "Name")
           + identifier("Win32_BaseBoard", "SerialNumber");
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }

        public string _GetVideoID()
        {
            try
            {

            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }

        public string _GetMacID()
        {
            try
            {

            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }


        public string _GetValue()
        {
            try
            {
                if (string.IsNullOrEmpty(fingerPrint))
                {
                    fingerPrint = GetHash(EncrytionHash.Kunci.Encrypt(_GetDeviceID() + "AKBAR" )) ;
                }
                return fingerPrint;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }


        public string _GetNomerSeri()
        {

            string NoSeri = "";
            try
            {
                NoSeri = EncrytionHash.Kunci.Encrypt(_GetDeviceID() + "AKBAR");
                return NoSeri;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
            return "";
        }
    }
}
