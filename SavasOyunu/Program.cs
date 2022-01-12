using System;
using System.Collections.Generic;

namespace SavasOyunu
{
    class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Oyunu bitirmek için ordundaki askerler bitmeden 3.seviyeye ulaşmalısın.");
            Console.WriteLine("Mağazadan kendine paranın yettiği askeri satın alabilirsin !");
            Console.WriteLine("Oyuna başlarken ordunuzda 4 tank vardır.Oyun içerisinde satın alarak arttırabilirsiniz !");
            Console.WriteLine("Askerlerini savaş alanında düşman birliklerine karşı göndererek onları yenmelisin.");
            Console.WriteLine("Savaş alanında savaşmak için 1 inputunu girdiğinde düşman ile 3 turluk bir savaş başlar.");
            Console.WriteLine("Savaş alanında düşmana karşı 3 turluk bir savaşa girersin.Kazandığında birliğin yerinde kalır ve para kazanırsın.");
            Console.WriteLine("Eğer bir turda kaybedersen para alamazsın ve ordundaki asker ölür.");
            Console.WriteLine("Düşmana art arda 3 kere kaybedersen ve ordunda hala 1 veya 1'den fazla asker varsa kaybetme bonusu alırsın.");
            Console.WriteLine("Eğer ordunda hiç asker kalmamışsa oyunu kaybedersin !.");
            Console.WriteLine("Eğer düşmana tank gönderirsen kazanma şansı yüksektir.Atlı asker ve askerin kazanma şansı daha azdır.");
            Console.WriteLine("80 paran olduğunda orduna seviye atlatabilirsin.");
            Console.WriteLine("3.seviyeye geldiğinde oyun bitecektir.");
            Console.WriteLine("***************************************************************************");
            //-------------------------------------------------------------------------------------------------------------------------------//

            Mekan mekan;
            Oyuncu oyuncu = new Oyuncu();  //burada nesne oluşturup onun özelliklerine başlangıç değerleri atadım.

            oyuncu.Ordu = new List<string>();
            oyuncu.Ordu.Add("Tank");
            oyuncu.Ordu.Add("Tank");
            oyuncu.Ordu.Add("Tank");
            oyuncu.Ordu.Add("Tank");
            oyuncu.Para = 20;
            oyuncu.Seviye = 1;
          

            while (true)  // burada sonsuz döngü açıyoruz oyunumuz sürekli devam etmesi için.
            {
                Console.WriteLine();
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Seçiminiz : ");
                Console.WriteLine("1-Mağaza --> Asker satın almak için girebilirsin.");
                Console.WriteLine("2-Savaş Alanı --> Karşına çıkan düşmanları yen!");
                Console.WriteLine("3-Seviye Atlama --> Oyunu bitirmek için paran yetiyorsa seviye atla !");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)  // switch case içerisinde çok biçimcilik kullandım.
                {
                    case 1:
                        mekan = new Magaza(oyuncu);  
                        break;
                    case 2:
                        mekan = new SavasAlani(oyuncu);
                        break;
                    case 3:
                        mekan = new SeviyeAtla(oyuncu);
                        break;
                    default:
                        Console.WriteLine("Geçerli bir değer giriniz !");
                        break;
                }

                //Bu ikiside her bir mekandan çıktığında her zaman kontrol etmesi için.Bu iki şarttan birisi sağlanırsa 
                //37.satırda açtığımız sonsuz döngü break ile kırılıp oyunun bitmesini sağlıyor.
                if (oyuncu.Ordu.Count == 0)
                {
                    Console.WriteLine("Oyun Bitti ! Yenildiniz !");
                    break;
                }
                if (oyuncu.Seviye == 3)
                {
                    Console.WriteLine("3.Seviyeye ulaştınız oyunu bitirdiniz !");
                    break;
                }

            }
        }
    }
}