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
            //atv.Add("fill");
        }

        public void setIsvykimas()
        {
            isv.Add("08:33");
            isv.Add("09:00");
            isv.Add("08:37");
            isv.Add("09:15");
            //isv.Add("fill");
        }

        public void getAllTimes()
        {
            using (var e1 = atv.GetEnumerator())
            using (var e2 = isv.GetEnumerator())

                while (e1.MoveNext() && e2.MoveNext())
                {
                    var item1 = e1.Current;
                    var item2 = e2.Current;
                    DateTime dateTime = DateTime.ParseExact(item1, "HH:mm",
                                                CultureInfo.InvariantCulture);
                    DateTime dateTim = DateTime.ParseExact(item2, "HH:mm",
                                                CultureInfo.InvariantCulture);

                    Console.WriteLine(dateTime.Hour + ":" + dateTime.Minute + "-" + dateTim.Hour + ":" + dateTim.Minute);

                }
        }

        public void searchBus()
        {
            Console.WriteLine("iveskite atvykimo laiką");

            String str = Convert.ToString(Console.ReadLine());
            DateTime dateTime1 = DateTime.ParseExact(str, "HH:mm",
                                        CultureInfo.InvariantCulture);
            Console.WriteLine("iveskite išvykimo laiką");
            String str1 = Convert.ToString(Console.ReadLine());
            DateTime dateTime2 = DateTime.ParseExact(str1, "HH:mm",
                                        CultureInfo.InvariantCulture);

            Console.WriteLine(dateTime1);
            Console.WriteLine(dateTime2);

            using (var e3 = atv.GetEnumerator())
            using (var e4 = isv.GetEnumerator())
                while (e3.MoveNext() && e4.MoveNext())
                {
                    var item1 = e3.Current;
                    var item2 = e4.Current;
                    DateTime dateTime = DateTime.ParseExact(item1, "HH:mm",
                                                CultureInfo.InvariantCulture);
                    DateTime dateTim = DateTime.ParseExact(item2, "HH:mm",
                                                CultureInfo.InvariantCulture);
                    if (dateTime1 <= dateTime && dateTime2 >= dateTim)
                    {
                        atvykimas++;
                        Console.WriteLine("[" + dateTime + "-" + dateTim + "]");
                    }

                }
            if (atvykimas != 0)
            {
                Console.WriteLine("atvyksta " + atvykimas + " išvyksta" + isvykimas);
                atvykimas = 0;
            }
            else
                Console.WriteLine("Nevaziuoja jokie autobusai");
        }

        public void addBus(String atv_time, String isv_time)
        {         
            atv.Add(atv_time);
            isv.Add(isv_time);       
        }

       
    }
}
