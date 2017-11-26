using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_stops
{
    class Bus
    {
        int atvykimas = 0;
        int isvykimas = 0;
        HashSet<String> atv = new HashSet<String>();
        HashSet<String> isv = new HashSet<String>();

        public void setAtvykimas()
        {
            atv.Add("08:24");
            atv.Add("08:20");
            atv.Add("08:32");
            atv.Add("09:00");
            
        }

        public void setIsvykimas()
        {
            isv.Add("08:33");
            isv.Add("09:00");
            isv.Add("08:37");
            isv.Add("09:15");
          
        }

        public void getAllTimes()
        {
            using (var e1 = atv.GetEnumerator())
            using (var e2 = isv.GetEnumerator())

                while (e1.MoveNext() && e2.MoveNext())
                {
                    var item1 = e1.Current;
                    var item2 = e2.Current;
                    DateTime atvTime = DateTime.ParseExact(item1, "HH:mm",
                                                CultureInfo.InvariantCulture);
                    DateTime isvTime = DateTime.ParseExact(item2, "HH:mm",
                                                CultureInfo.InvariantCulture);

                    Console.WriteLine(atvTime.Hour + ":" + atvTime.Minute + " - " + isvTime.Hour + ":" + isvTime.Minute);

                }
        }

        public void searchBus()
        {
            Console.WriteLine("atvykimo laikas: ");      
            String atvInput = Convert.ToString(Console.ReadLine());
            DateTime atvTime = DateTime.ParseExact(atvInput, "HH:mm",
                                        CultureInfo.InvariantCulture);

            Console.WriteLine("išvykimo laikas: ");
            String isvInput = Convert.ToString(Console.ReadLine());
            DateTime isvTime= DateTime.ParseExact(isvInput, "HH:mm",
                                        CultureInfo.InvariantCulture);

            Console.WriteLine(atvTime);
            Console.WriteLine(isvTime);

            using (var e3 = atv.GetEnumerator())
            using (var e4 = isv.GetEnumerator())
                while (e3.MoveNext() && e4.MoveNext())
                {
                    var item1 = e3.Current;
                    var item2 = e4.Current;
                    DateTime dateTimeA = DateTime.ParseExact(item1, "HH:mm",
                                                CultureInfo.InvariantCulture);
                    DateTime dateTimeI = DateTime.ParseExact(item2, "HH:mm",
                                                CultureInfo.InvariantCulture);
                    if (atvTime <= dateTimeA && isvTime >= dateTimeI)
                    {
                        atvykimas++;
                        Console.WriteLine("[" + dateTimeA + "-" + dateTimeI + "]");
                    }

                }
            if (atvykimas != 0)
            {
                Console.WriteLine("atvyksta: " + atvykimas);
                atvykimas = 0;
            }
            else
                Console.WriteLine("Tokių autobusų nėra");
        }

        public void addBus(String atv_time, String isv_time)
        {         
            atv.Add(atv_time);
            isv.Add(isv_time);       
        }

    }
}
