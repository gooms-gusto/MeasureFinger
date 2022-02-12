using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hitungan
{
   public  class Hitung:IHitung
    {


        public IDominasiOtak GetDominasiOtak()
        {
            return new DominasiOtak();
        }

        public IGayaBelajar GetGayaBelajar()
        {
            return new GayaBelajar();
        }

        public IGayaKerja GetGayaKerja()
        {
            return new GayaKerja();
        }

        public IPotentisialSkill GetPotentisialSkill()
        {
            return new PotensialSkill();
        }
    }
}
