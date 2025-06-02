using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace Event.Ukol;

class Program
{
    public class Event
    {
        public string Jmeno { get; set; }
        public string Datum { get; set; }

        public DateTime DatumUdalosti { get; set; }

        public Event(string jmeno, string datum)
        {
            Jmeno = jmeno;
            Datum = datum;
            string[] poleDat = Datum.Split("-");
            int year = int.Parse(poleDat[0]);
            int month = int.Parse(poleDat[1]);
            int day = int.Parse(poleDat[2]);
            DatumUdalosti = new DateTime(year, month, day);
            
        }

        public void List()
        {
            TimeSpan dny = DatumUdalosti - DateTime.Now;
            if (dny.Days < 0)
            {
                Console.WriteLine($"Event {Jmeno} with date {DatumUdalosti} happened {Math.Abs(dny.Days)} days ago.");
            }
            else
            {
                Console.WriteLine($"Event {Jmeno} with date {DatumUdalosti} will happen in {dny.Days} days");
            }

        }

        public void Stats()
        {
            Dictionary<DateTime, int> udalosti = new Dictionary<DateTime, int>();
           

            foreach (var polozka in udalosti)
            {
                Console.WriteLine($"Date:{polozka.Key}: events:{polozka.Value}");
            }
           

        }
          

        
        public static string NactiUdalostOdUzivatele()
        {
            Console.WriteLine("Uzivateli zadej název a datum udalosti ve formátu: EVENT;jmeno udalosti ;datum ve formatu yyyy-mm-dd");
            string vstupUzivatele = Console.ReadLine();
            return vstupUzivatele;

        }


        static void Main(string[] args)
        {
            Event lekce = new Event("Lekce Czechitas", "2025-05-29");
            Event koncert = new Event("Koncert", "2025-05-28");
            Event oslava = new Event("Oslava", "2025-06-15");
            Event zkouska = new Event("Zkouska", "2025-06-15");

            List<Event> eventsList = new List<Event>()
        {   lekce,
            koncert,
            oslava,
            zkouska
        };

      

          

            while (true)
            {
                Console.WriteLine("1 - ulozit novou událost");
                Console.WriteLine("2 - vypsat udalosti");
                Console.WriteLine("3 - vypsat datum a pocet udalosti");
                Console.WriteLine("4 - ukoncit aplikaci");
                Console.WriteLine("Uzivateli, zvol akci:");
                int akce = int.Parse(Console.ReadLine());

                switch (akce)
                {
                    case 1:
                        string[] poleVstupu = NactiUdalostOdUzivatele().Split(";");
                        string jmeno = poleVstupu[1];
                        string datum = poleVstupu[2];
                        var newEvent = new Event(jmeno, datum);
                        eventsList.Add(newEvent);
                        break;

                    case 2:
                        foreach (Event name in eventsList)
                        {
                            name.List();
                        }
                        break;
                    case 3:
                        foreach (Event name in eventsList)
                        {
                            name.Stats();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ukoncuji apikaci");
                        return;


                }

            }


        }// endMain      
    }
}// endProgram

