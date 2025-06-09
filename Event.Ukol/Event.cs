using System;

namespace Event.Ukol;
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
        try
        {
            int year = int.Parse(poleDat[0]);
            int month = int.Parse(poleDat[1]);
            int day = int.Parse(poleDat[2]);
            DatumUdalosti = new DateTime(year, month, day);

        }
        catch
        {
            throw new InvalidOperationException("Spatne zadany datum udalosti.");
            }
            
        }

        public void VypisUdalostiAKolikDniZbyva()
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

        }