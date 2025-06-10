using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace Event.Ukol;

class Program
{ 
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
            var udalosti = new Dictionary<DateTime, int>();
            
            foreach (var pocetUdalosti in eventsList.GroupBy(p => p.DatumUdalosti))
        {
            var cisloUdalosti = pocetUdalosti.Count();
            udalosti.Add(pocetUdalosti.Key ,cisloUdalosti);
        }
        
            while (true)
            {
                Console.WriteLine("Pro ulozeni nove udalosti zadej: EVENT;[jmeno udalosti];[datum udalosti ve formatu- yyyy-mm-dd]");
                Console.WriteLine("LIST - vypsat udalosti");
                Console.WriteLine("STATS - vypsat datum a pocet udalosti");
                Console.WriteLine("END - ukoncit aplikaci");
                Console.WriteLine("Uzivateli, zvol akci:");
                string [] poleAkce = Console.ReadLine().ToUpper().Split(";");

                switch (poleAkce [0])
                {
                    case "EVENT":
                   
                    try
                    {           string[] poleVstupu = poleAkce;
                                string jmeno = poleVstupu[1];
                                string datum = poleVstupu[2];
                                var newEvent = new Event(jmeno, datum);
                                eventsList.Add(newEvent);
                  

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Nastala chyba:" + ex.Message);
                    }
                    catch
                    {
                        Console.WriteLine("Udalost zadana ve spatnem formatu. Format musi byt EVENT;[event name] ; [event date - yyyy-mm-dd]");
                    }

                        break;

                    case "LIST":
                        foreach (Event name in eventsList)
                        {
                            name.VypisUdalostiAKolikDniZbyva();
                        }
                        break;
                    case "STATS":
                            foreach (var polozka in udalosti)
                            {

                         Console.WriteLine($"Date:{polozka.Key}: events:{polozka.Value}");
                                }
                        break;

                    case "END":
                        Console.WriteLine("Ukoncuji apikaci");
                        return;


                }

            }


        }// endMain      
    }
// endProgram

