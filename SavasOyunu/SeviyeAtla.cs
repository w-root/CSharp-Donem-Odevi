using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasOyunu
{   
    //Burada Seviye atlama yeri bir yer, mekan olduğu için Mekan sınıfını kalıtım olarak alıyor ve buda bize çok biçimciliği
    //kullanmamıza olanak sağlıyor.
    public class SeviyeAtla : Mekan
    {
        Oyuncu _oyuncu;
        public SeviyeAtla(Oyuncu oyuncu) : base(oyuncu)
        {
            _oyuncu = oyuncu;
            Seviye();
        }
        void Seviye()
        {
            if(_oyuncu.Para >= 80)
            {
                _oyuncu.Para -= 80;
                _oyuncu.Seviye++;
                Console.WriteLine("Seviye atladınız");
                Console.WriteLine("Kalan paranız {0}",_oyuncu.Para);
            }
            else
            {
                Console.WriteLine("Paranız : {0} ", _oyuncu.Para);
                Console.WriteLine("Paranız Yetersiz !");
            }
        }
    }
}
