using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasOyunu
{
    public class Oyuncu
    {
        //Burada 3 field içinde yaptığım olay kapsülleme, dışarıdan erişilmesini kapatıp get ve set ile erişiliyor.

        private List<string> ordu; // field olarak tanımladık ve private yaptık çünkü dışarıdan erişilmesin.
        public List<string> Ordu   // property olarak tanımladık çünkü  dışarıdan erişilsin diye.
        {
            get { return ordu; }
            set { ordu = value; }
        }


        private int seviye; // field
        public int Seviye  // property
        {
            get { return seviye; }
            set { seviye = value; }
        }


        private int para; // field
        public int Para   // property
        {
            get { return para; }
            set { para = value; }
        }

        public Oyuncu()
        {
           
        }
    }
}
