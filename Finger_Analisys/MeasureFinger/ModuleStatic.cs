using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace MeasureFinger
{
   public  class ModuleStatic
   {
       private static  string _path_utama;
       private static bool  _Trial;

          public static string SetPathUtama
          {
              get { return _path_utama; }
              set { _path_utama = value; }
          }


       public static bool GetSetTrial { get { return _Trial; } set { _Trial = value; } }


       public static string GetPathGambar
       {
           get { return _path_utama + "\\_gambar\\"; }
       }

       public static void SetFolderID(string IDPasien)
       {
           Directory.CreateDirectory(GetPathGambar + IDPasien);
       }
   }
}
