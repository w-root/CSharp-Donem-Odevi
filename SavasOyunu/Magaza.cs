using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasOyunu
{
    //Burada magaza bir yer, mekan olduğu için Mekan sınıfını kalıtım olarak alıyor ve buda bize çok biçimciliği
    //kullanmamıza olanak sağlıyor.
    public class Magaza : Mekan
    {
        Oyuncu _oyuncu;
        public Magaza(Oyuncu oyuncu) : base(oyuncu)
        {
            _oyuncu = oyuncu;
            Alisveris();
        }

        //Burası çok basit bir alışveriş mantığı kullanıcı almak istediği askeri input olarak giriyor
        //Switch case yapısı ile basit bir yapı kurarak ordusuna askeri ekliyoruz ve parasını azaltıyoruz.
        public void Alisveris()
        {
            Console.WriteLine("Paranız : " + _oyuncu.Para);
            Console.WriteLine("1-Asker      -->    Hasar  : 3  ---  Fiyatı : 15");
            Console.WriteLine("2-Atlı Asker -->    Hasar  : 5  ---  Fiyatı : 20");
            Console.WriteLine("3-Tank       -->    Hasar  : 7  ---  Fiyatı : 25");
            Console.WriteLine("4-Çıkış");

            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    if (_oyuncu.Para < 15)
                    {
                        Console.WriteLine("Paranız yetersiz ! ");
                        break;
                    }
                    _oyuncu.Ordu.Add("Asker");        
                    _oyuncu.Para -= 15;
                    break;
                case 2:
                    if (_oyuncu.Para < 20)
                    {
                        Console.WriteLine("Paranız yetersiz ! ");
                        break;
                    }
                    _oyuncu.Ordu.Add("Atlı Asker");
                    _oyuncu.Para -= 20;
                    break;
                case 3:
                    if (_oyuncu.Para < 25)
                    {
                        Console.WriteLine("Paranız yetersiz ! ");
                        break;
                    }
                    _oyuncu.Ordu.Add("Tank");
                    _oyuncu.Para -= 25;
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Geçerli bir değer giriniz ! ");
                    break;
            }
        }
    }
}