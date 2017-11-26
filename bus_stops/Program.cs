using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bus_stops
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus bus = new Bus();
            bus.setAtvykimas();
            bus.setIsvykimas();

            int x = 0;
            while (x != 4)
            {

                Console.WriteLine("----");
                Console.WriteLine("1. Add new bus");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. All");
                Console.WriteLine("4. Quit");


                x = int.Parse(Console.ReadLine());

                switch (x)
                {
                    case 1:
                       
                        Console.WriteLine("atvykimo laikas: ");
                        String atv_time = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("išvykimo laikas: ");
                        String isv_time = Convert.ToString(Console.ReadLine());
                        bus.addBus(atv_time, isv_time);

                        Console.WriteLine("Autobuso laikas sėkmingai pridėtas.");
                        break;
                    case 2:
                        bus.searchBus();
                        break;
                    case 3:
                        bus.getAllTimes();

                        break;

                    default:
                        Console.WriteLine("Neįmanoma");
                        break;
                }
            }
        }
    }
}
