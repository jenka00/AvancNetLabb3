using System;
using System.Diagnostics;
using System.Threading;

namespace AvancNetLabb3
{
    class Program
    {
        static void Main(string[] args)
        {
            string RaceWinner = "";
            Car c1 = new Car("BMW");
            Car c2 = new Car("Mercedes");

            Thread thr1 = new Thread(c1.RandomMethod)
            {
                Name = c1.CarName
            };

            Thread thr2 = new Thread(c2.RandomMethod)
            {
                Name = c2.CarName
            };
            thr1.IsBackground = true;
            thr2.IsBackground = true;

            Console.WriteLine($"{c1.CarName} och {c2.CarName} börjar köra.");

            thr1.Start();
            thr2.Start();

            Console.WriteLine("Tryck enter för att se ställning i pågående tävling");
            while (thr1.IsAlive || thr2.IsAlive)
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine($"\nBil: {c1.CarName} \tHastighet: {c1.CarSpeed} km/h \tAvlagd sträcka: {c1.TravledDistance:F2} km");
                        Console.WriteLine($"\nBil: {c2.CarName} \tHastighet: {c2.CarSpeed} km/h \tAvlagd sträcka: {c2.TravledDistance:F2} km");
                    }
                }
                if (!thr1.IsAlive && thr2.IsAlive)
                {
                    RaceWinner = c1.CarName;
                }
                else if (thr1.IsAlive && !thr2.IsAlive)
                {
                    RaceWinner = c1.CarName;
                }
            }
            Console.WriteLine($"\nVinnare är {RaceWinner}.");
        }
    }
}
