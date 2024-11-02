using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANAV_OTOMASYONU
{
    public class HAL
    {
        internal static HalMusteri m = new HalMusteri();
        
       
        internal static List<Meyve> meyveler = new List<Meyve>()
        {
            new Meyve(){ad="muz",fiyat=100,alınan=0,tutar=0},
            new Meyve(){ad="çilek",fiyat=150,alınan=0,tutar=0},
            new Meyve(){ad="armut",fiyat=50,alınan=0,tutar=0}
        };
        internal static List<Sebze> sebzeler = new List<Sebze>()
        {
            new Sebze(){ad="patlıcan",fiyat=75,alınan=0,tutar=0},
            new Sebze(){ad="biber",fiyat=40,alınan=0,tutar=0},
            new Sebze(){ad="bamya",fiyat=200,alınan=0,tutar=0}
        };




        internal static void URUNYAZDIR()
        {
            Console.WriteLine("meyveler");
            foreach (Meyve item in meyveler)
            {
                Console.WriteLine(item.ad + ":" + item.fiyat);
            }
            Console.WriteLine("sebzeler");
            foreach (Sebze item in sebzeler)
            {
                Console.WriteLine(item.ad + ":" + item.fiyat);
            }




        }
        internal static void MEYVESATISI()
        {


            while (true)
            {
                Console.WriteLine("halden meyve almaya devam etmek istiyor musunuz?(e,h) ");
                string cevap = Console.ReadLine();
                if (cevap == "e")
                {
                    Console.WriteLine("meyveler");
                    foreach (Meyve item in meyveler)
                    {
                        Console.WriteLine(item.ad + ":" + item.fiyat);
                    }
                    Console.WriteLine("hangi meyveyi almak istiyorsunuz");
                    string urun = Console.ReadLine();
                    Meyve meyve = meyveler.FirstOrDefault(i => i.ad == urun);
                    int y = meyveler.IndexOf(meyve);
                    if (meyve == null)
                    {
                        Console.WriteLine("böyle bir meyve yok");
                        Console.WriteLine("bu meyveyi eklemeyi istermisiniz?(e,h)");
                        string yanit = Console.ReadLine();
                        if (yanit == "e")
                        {
                            Console.WriteLine("bu meyvenin kilosu ne kadar olsun");
                            double yeniUrunFiyat = Convert.ToDouble(Console.ReadLine());
                            meyveler.Add(new Meyve() { ad = urun, fiyat = yeniUrunFiyat, alınan = 0, tutar = 0 });
                            y = meyveler.Count - 1;
                        }
                        else if (yanit == "h")
                        {

                            break;
                        }
                    }
                    Meyve n = meyveler[y];
                    Console.WriteLine("kaç kilo almak istiyorsunuz");
                    double kilo = Convert.ToDouble(Console.ReadLine());
                    n.alınan += kilo;
                    n.tutar += kilo * n.fiyat;
                   
                    HalMusteri meyve2 = HalMusteri.meyves.FirstOrDefault(i => i.ad == urun);
                    int w = HalMusteri.meyves.IndexOf(meyve2);
                    if (meyve2 == null)
                    {
                        HalMusteri.meyves.Add(new HalMusteri() { ad = urun });
                        w = HalMusteri.meyves.Count - 1;
                    }
                    HalMusteri e = HalMusteri.meyves[w];
                    e.alınan += kilo;
                    e.meyveTutari += e.alınan * n.fiyat;
                    m.meyveSepetTutari += e.alınan * n.fiyat;
                    MANAV meyve1 = MANAV.meyves.FirstOrDefault(i => i.ad == urun);
                    int r = MANAV.meyves.IndexOf(meyve1);
                    if (meyve1 == null)
                    {
                        MANAV.meyves.Add(new MANAV() { ad = urun, fiyat = n.fiyat * 1.2 });
                        r = MANAV.meyves.Count - 1;

                    }
                    MANAV t = MANAV.meyves[r];
                    t.stok = n.alınan;


                }
                else if (cevap == "h")
                {

                    break;
                }
                else { Console.WriteLine("hatalı seçim"); }



            }


        }
        internal static void SEBZESATISI()
        {


            while (true)
            {
                Console.WriteLine("halden sebze almaya devam etmek istiyor musunuz?(e,h)");
                string cevap = Console.ReadLine();
                if (cevap == "e")
                {
                    Console.WriteLine("sebzeler");
                    foreach (Sebze item in sebzeler)
                    {
                        Console.WriteLine(item.ad + ":" + item.fiyat);
                    }
                    Console.WriteLine("hangi sebzeyi almak istiyorsunuz");
                    string urun = Console.ReadLine();
                    Sebze sebze = sebzeler.FirstOrDefault(i => i.ad == urun);
                    int y = sebzeler.IndexOf(sebze);
                    if (y == -1)
                    {
                        Console.WriteLine("böyle bir sebze yok");
                        Console.WriteLine("bu sebzeyi eklemeyi istermisiniz?(e,h)");
                        string yanit = Console.ReadLine();
                        if (yanit == "e")
                        {
                            Console.WriteLine("bu sebzenin kilosu ne kadar olsun");
                            double yeniUrunFiyat = Convert.ToDouble(Console.ReadLine());
                            sebzeler.Add(new Sebze() { ad = urun, fiyat = yeniUrunFiyat, alınan = 0, tutar = 0 });
                            y = meyveler.Count - 1;
                        }
                        else if (yanit == "h")
                        {
                            break;
                        }

                    }
                    Sebze s = sebzeler[y];
                    Console.WriteLine("kaç kilo almak istiyorsunuz");
                    double kilo = Convert.ToDouble(Console.ReadLine());
                    s.alınan += kilo;

                    s.tutar += kilo * s.fiyat;
                   
                    HalMusteri sebze2 = HalMusteri.sebzes.FirstOrDefault(i => i.ad == urun);
                    int w = HalMusteri.sebzes.IndexOf(sebze2);
                    if (sebze2 == null)
                    {
                        HalMusteri.sebzes.Add(new HalMusteri() { ad = urun });
                        w = HalMusteri.sebzes.Count - 1;
                    }
                    HalMusteri e = HalMusteri.sebzes[w];
                    e.alınan += kilo;
                    e.sebzeTutari += e.alınan * s.fiyat;
                    m.sebzeSepetTutari += e.alınan * s.fiyat;

                    MANAV sebze1 = MANAV.sebzes.FirstOrDefault(i => i.ad == urun);
                    int r = MANAV.sebzes.IndexOf(sebze1);
                    if (sebze1 == null)
                    {
                        MANAV.sebzes.Add(new MANAV() { ad = urun, fiyat = s.fiyat * 1.2, stok = 0, tutar = 0 });
                        r = MANAV.sebzes.Count - 1;
                    }

                    MANAV t = MANAV.sebzes[r];
                    t.stok = s.alınan;

                }
                else if (cevap == "h")
                {

                    break;
                }
                else { Console.WriteLine("hatalı seçim"); }
            }

        }
        internal static void HALSATISI()
        {
            Console.WriteLine("Hal e hoşgeldiniz");
            HAL.URUNYAZDIR();


            while (true)
            {
                Console.WriteLine(" ne almak istiyorsunuz?(m,s)çıkış için-0");
                string cevap = Console.ReadLine();
                if (cevap == "m") { HAL.MEYVESATISI(); }
                else if (cevap == "s") { HAL.SEBZESATISI(); }
                else if (cevap == "0") { break; }
                else { Console.WriteLine("hatalı seçim"); }
            }
            foreach (HalMusteri meyve in HalMusteri.meyves)
            {
                Console.WriteLine($"{meyve.ad},alınan miktar:{meyve.alınan},tutar:{meyve.meyveTutari}");
            }
            Console.WriteLine("toplam meyve tutarı:"+m.meyveSepetTutari);
            foreach (HalMusteri sebze in HalMusteri.sebzes)
            {
                Console.WriteLine($"{sebze.ad},alınan miktar:{sebze.alınan},tutar:{sebze.sebzeTutari}");
            }
            Console.WriteLine("toplam sebze tutarı:" + m.sebzeSepetTutari);
            Console.WriteLine($"toplam tutar:{m.meyveSepetTutari + m.sebzeSepetTutari}");
        }
    
    }
}
