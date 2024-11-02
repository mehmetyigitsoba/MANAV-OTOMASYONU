using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANAV_OTOMASYONU
{
    internal class MANAV
    {
        public string ad { get; set; }
        public double fiyat { get; set; }
        public double tutar { get; set; }
        public double stok { get; set; }
        internal static List<MANAV> meyves = new List<MANAV>() { };
        internal static List<MANAV> sebzes = new List<MANAV>() { };
        internal static ManavMusteri m = new ManavMusteri();
        internal static List<ManavMusteri> musteri = new List<ManavMusteri>() { };


        internal static void MANAVSATISI()
        {
            Console.WriteLine("Manava hoşgeldiniz");
            while (true)
            {
                Console.WriteLine(" ne almak istiyorsunuz(m,s) çıkış için-0");
                string cevap = Console.ReadLine();
                if (cevap == "m")
                {
                    while (true)
                    {
                        Console.WriteLine("meyve almaya devam etmek istiyor musunuz(e,h)");
                        string yanit = Console.ReadLine();
                        if (yanit == "e")
                        {
                            Console.WriteLine("MEYVELER");
                            foreach (var item in meyves)
                            {
                                Console.WriteLine(item.ad + " : " + item.fiyat);
                            }
                            Console.WriteLine("hangi meyveyi almak istiyorsunuz");
                            string urun = Console.ReadLine();
                            MANAV meyve1 = meyves.FirstOrDefault(i => i.ad == urun);
                            int y = meyves.IndexOf(meyve1);
                            if (y == -1)
                            {
                                Console.WriteLine("böyle bir meyve yoktur");
                                break;
                            }

                            Console.WriteLine("kaç kilo istiyorsunuz");
                            double kilo = Convert.ToDouble(Console.ReadLine());
                            if (kilo <= meyve1.stok)
                            {

                                ManavMusteri meyve2 = ManavMusteri.meyves.FirstOrDefault(i => i.ad == urun);
                                int r = ManavMusteri.meyves.IndexOf(meyve2);
                                if (meyve2 == null)
                                {
                                    ManavMusteri.meyves.Add(new ManavMusteri() { ad = urun });
                                    r = ManavMusteri.meyves.Count - 1;
                                }
                                ManavMusteri t = ManavMusteri.meyves[r];
                                t.alınan += kilo;

                                t.meyveTutari += t.alınan * meyve1.fiyat;
                                m.meyveSepetTutari += t.alınan * meyve1.fiyat;
                                meyve1.stok -= kilo;
                            }
                            else
                            {
                                Console.WriteLine("yeterli stok yok,alabiceğiniz stok:" + meyve1.stok);
                                Console.WriteLine("mevcut stoğun tamamını almak istiyor musunuz?(e,h)");
                                string secenek = Console.ReadLine();
                                if (secenek == "e")
                                {

                                    ManavMusteri meyve2 = ManavMusteri.meyves.FirstOrDefault(i => i.ad == urun);
                                    int r = ManavMusteri.meyves.IndexOf(meyve2);
                                    if (meyve2 == null)
                                    {
                                        ManavMusteri.meyves.Add(new ManavMusteri() { ad = urun });
                                        r = ManavMusteri.meyves.Count - 1;
                                    }
                                    ManavMusteri t = ManavMusteri.meyves[r];
                                    t.alınan += meyve1.stok;
                                    t.meyveTutari += meyve1.stok * meyve1.fiyat;

                                    m.meyveSepetTutari = t.alınan * meyve1.fiyat;
                                    meyve1.stok -= meyve1.stok;

                                }
                                else if (secenek == "h") { break; }
                                else { Console.WriteLine("hatalı seçim"); }
                            }




                        }
                        else if (yanit == "h") { break; }
                        else { Console.WriteLine("hatalı seçim"); }
                    }

                }
                else if (cevap == "s")
                {
                    while (true)
                    {
                        Console.WriteLine("sebze almaya devam etmek istiyor musunuz(e,h)");
                        string yanit = Console.ReadLine();
                        if (yanit == "e")
                        {
                            Console.WriteLine("SEBZELER");
                            foreach (var item in sebzes)
                            {
                                Console.WriteLine(item.ad + " : " + item.fiyat);
                            }
                            Console.WriteLine("hangi sebzeyi almak istiyorsunuz");
                            string urun = Console.ReadLine();
                            MANAV sebze1 = sebzes.FirstOrDefault(i => i.ad == urun);
                            int y = sebzes.IndexOf(sebze1);
                            if (y == -1)
                            {
                                Console.WriteLine("böyle bir sebze yoktur");
                                break;
                            }

                            Console.WriteLine("kaç kilo istiyorsunuz");
                            double kilo = Convert.ToDouble(Console.ReadLine());
                            if (kilo <= sebze1.stok)
                            {

                                ManavMusteri sebze2 = ManavMusteri.sebzes.FirstOrDefault(i => i.ad == urun);
                                int r = ManavMusteri.sebzes.IndexOf(sebze2);
                                if (sebze2 == null)
                                {

                                    ManavMusteri.sebzes.Add(new ManavMusteri() { ad = urun });
                                    r = ManavMusteri.sebzes.Count - 1;
                                }
                                ManavMusteri t = ManavMusteri.sebzes[r];
                                t.alınan += kilo;
                                t.sebzeTutari += t.alınan * sebze1.fiyat;
                                m.sebzeSepetTutari += t.alınan * sebze1.fiyat;
                                sebze1.stok -= kilo;
                            }
                            else
                            {
                                Console.WriteLine("yeterli stok yok,alabiceğiniz stok:" + sebze1.stok);
                                Console.WriteLine("mevcut stoğun tamamını almak istiyor musunuz?(e,h)");
                                string secenek = Console.ReadLine();
                                if (secenek == "e")
                                {
                                    ManavMusteri sebze2 = ManavMusteri.sebzes.FirstOrDefault(i => i.ad == urun);
                                    int r = ManavMusteri.sebzes.IndexOf(sebze2);
                                    if (sebze2 == null)
                                    {
                                        ManavMusteri.sebzes.Add(new ManavMusteri() { ad = urun });
                                        r = ManavMusteri.sebzes.Count - 1;
                                    }
                                    ManavMusteri t = ManavMusteri.sebzes[r];
                                    t.alınan += sebze1.stok;

                                    t.sebzeTutari += sebze1.stok * sebze1.fiyat;
                                    m.sebzeSepetTutari = t.alınan * sebze1.fiyat;
                                    sebze1.stok -= sebze1.stok;

                                }
                                else if (secenek == "h") { break; }
                                else { Console.WriteLine("hatalı seçim"); }
                            }





                        }
                        else if (yanit == "h")
                        {

                            break;
                        }
                        else { Console.WriteLine("hatalı seçim"); }
                    }

                }
                else if (cevap == "0")
                {
                    foreach (var item in ManavMusteri.meyves)
                    {
                        Console.WriteLine(item.ad + "alınan:" + item.alınan + "tutar:" + item.meyveTutari);
                    }
                    Console.WriteLine("toplam meyve tutarı:" + m.meyveSepetTutari);
                    foreach (var item in ManavMusteri.sebzes)
                    {
                        Console.WriteLine(item.ad + "alınan:" + item.alınan + "tutar:" + item.sebzeTutari);
                    }
                    Console.WriteLine("toplam sebze tutarı:" + m.sebzeSepetTutari);
                    Console.WriteLine("toplam tutar:" + (m.meyveSepetTutari + m.sebzeSepetTutari));
                    break;
                }
                else { Console.WriteLine("hatalı seçim"); }
            }
        }
    }
}
