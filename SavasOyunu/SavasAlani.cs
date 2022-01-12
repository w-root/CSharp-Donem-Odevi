using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasOyunu
{
    //Burada SavasAlani bir yer, mekan olduğu için Mekan sınıfını kalıtım olarak alıyor ve buda bize çok biçimciliği
    //kullanmamıza olanak sağlıyor.
    public class SavasAlani : Mekan
    {
        Random rastgele = new Random();
       
        Oyuncu _oyuncu;
        public SavasAlani(Oyuncu oyuncu) : base(oyuncu)
        {
            _oyuncu = oyuncu;
            SavasSecim();
        }


        //Bu metot constructor da çalışıyor yani bu sınıftan bir nesne üretildiğinde.
        //Nesne üretmeyide Program.cs 53.satırda yaptığımız için SavasSecim() metodu çalışıyor.
        //Diğer sınıflardada aynı işlem geçerli. Bakınız: SeviyeAtla.cs,Magaza.cs
        public void SavasSecim()         
        {
            Console.WriteLine("Savaş alanındasın !");
            Console.WriteLine("Düşmanla savaşmak için 1 giriniz ! Çıkmak için 2 giriniz !");

            int menu = Convert.ToInt32(Console.ReadLine());

            if (menu == 1)
            {
                Savas();
            }
          
        }

        public void Savas()
        {
            int kaybetmeBonusu = 0;
            for (int i = 0; i < 3; i++) //Oyuncu düşman ile 3 turluk savaşa gireceği için for döngüsünü 3 kez döndürüyoruz.
            {
                if (_oyuncu.Ordu.Count > 0)
                {
                    Console.WriteLine("Düşman karşınızda!");
                    Console.WriteLine("Göndermek istediğiniz birliğin index numarasını giriniz seçiniz !");
                    for (int j = 0; j < _oyuncu.Ordu.Count; j++) //oyuncunu ordusunun üzerinde gezip ekrana yazdırıyoruz.
                    {
                        Console.WriteLine(j + "- " + _oyuncu.Ordu[j]); 
                    }

                    int askerNumarasi = Convert.ToInt32(Console.ReadLine());

                    if (_oyuncu.Ordu[askerNumarasi] == "Asker")
                    {
                        RastgeleKazanan(askerNumarasi, 5, ref kaybetmeBonusu);
                    }
                    else if (_oyuncu.Ordu[askerNumarasi] == "Atlı Asker")
                    {
                        RastgeleKazanan(askerNumarasi, 5, ref kaybetmeBonusu);
                    }
                    else
                    {
                        RastgeleKazanan(askerNumarasi, 4, ref kaybetmeBonusu);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        void RastgeleKazanan(int askerNumarasi,int max,ref int kaybetmeBonusu)
        {
          //Burada savaş alanında asker gönderdikten sonra kimin kazanacağını random sınıfından üretilen numarayla belirliyorum.
          //Eğer düşmana tank gönderirsen 2 ile 4 arasında sayı tutuyor.Yani ya 2 çıkıcak yada 3.
          //Çıkan sayı 2 ise oyuncu kazanıyor.
          //Atlı asker ve askerdede aynı durum geçerli ama daha fazla aralıklı sayı tutuluyor.Yani tank ta kazanma olasılığı %50
          //Atlı asker ve askerde kazanma olasılığı daha düşük.
          
          int sayi = rastgele.Next(2, max);
            Console.WriteLine("******************************************************");
            if (sayi == 2) { 
                Console.WriteLine("Bu turu kazandınız !");
                _oyuncu.Para += 25;
                Console.WriteLine("Yeni Paranız : {0}", _oyuncu.Para);
            }
            else
            {
                _oyuncu.Ordu.RemoveAt(askerNumarasi);
                kaybetmeBonusu++;
                Console.WriteLine("Askeriniz yenildi kaybettiniz !");
            }

            //Burada eğer düşmana karşı 3 turdada kaybedilirse oyuncunun parasına 50 ilave yapılıyor.
            if (kaybetmeBonusu == 3)
            {
                _oyuncu.Para += 50;
                Console.WriteLine("3 kere art arda kaybettiğiniz için bonus para verildi mağazadan asker satın alınız!");

            }
        }
    
    }

}
