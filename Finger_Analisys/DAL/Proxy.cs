using System;
using System.Collections.Generic;
using System.Text;
using DAL.Class;

namespace DAL
{
   public  class Proxy:IProxy 
    {
        #region IProxy Members

        public IPasien _GetPasien()
        {
          return new Pasien();
        }


        public ILisensi _GetLic()
        {
            return new Lisensi();
        }

        #endregion


        public ILogin _GetLogin()
        {
            return new Login();
        }


        public IProcessor _GetProcessor()
        {
            return new MyProcessor();
        }


        public IPerangkatKeras _GetHardware()
        {
            return new Hardware();
        }


        public ILimit _GetLimit()
        {
           return new Limit();
        }
    }
}
