using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace AvancNetLabb3
{
    public class Car
    {
        public string CarName { get; set; }
        public double CarSpeed { get; private set; }
        public double TravledDistance { get; set; }
        public double Time { get; set; }
        public double TrackLenght { get; set; }

        public Car(string carName)
        {
            this.CarName = carName;
            this.CarSpeed = 120;
            this.TravledDistance = 0;
            this.Time = 0;
            this.TrackLenght = 2;
        }

        public void Refuel()
        {
            Console.WriteLine($"\n{Thread.CurrentThread.Name} har fått slut på bensin.");
            Console.WriteLine($"{Thread.CurrentThread.Name} tankar...........");
            Thread.Sleep(30000);
            Console.WriteLine($"\n{Thread.CurrentThread.Name} har tankat färdigt. Fortsätter köra");
        }
        public void Puncture()
        {
            Console.WriteLine($"\n{Thread.CurrentThread.Name} har fått punktering.");
            Console.WriteLine($"{Thread.CurrentThread.Name} byter däck.........");
            Thread.Sleep(20000);
            Console.WriteLine($"\n{Thread.CurrentThread.Name} är färdig med däckbytet. Fortsätter köra");
        }
        public void BirdOnWindow()
        {
            Console.WriteLine($"\n{Thread.CurrentThread.Name} har krockat med en fågel.");
            Console.WriteLine($"{Thread.CurrentThread.Name} rengör vindrutan.........");
            Thread.Sleep(10000);
            Console.WriteLine($"\n{Thread.CurrentThread.Name}'s vindruta är ren igen. Fortsätter köra");
        }
        public double EngineBreakDown()
        {
            this.CarSpeed -= 1;
            Console.WriteLine($"\n{Thread.CurrentThread.Name} har fått motorfel och hastigheten sänks till {CarSpeed} km/h.");
            return CarSpeed;
        }
        public void Driving()
        {
            for (int seconds = 0; seconds < 3000 && TravledDistance < TrackLenght; seconds++)
            {
                Thread.Sleep(10);
                this.Time += 10;
                CalculateDistance();
            }            
        }
        public double CalculateDistance()
        {
            this.TravledDistance = CarSpeed * ((Time / (1000 * 60 * 60)) % 24);
            return TravledDistance;
        }

        public void RandomMethod()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                this.Time += 1000;
                this.TravledDistance += 0.033; 
            }           

            while (TravledDistance < TrackLenght)
            {
                double number;
                Random random = new Random();
                number = random.NextDouble();

                double caseRefuel = 0.02;
                double casePuncture = 0.04;
                double caseBird = 0.1;
                double caseEngine = 0.2;
                double caseDriving = 0.64;
                double caseTotal = caseRefuel + casePuncture + caseBird + caseEngine + caseDriving;

                if (number < caseRefuel)
                {
                    Refuel();
                    CalculateDistance();                   
                }
                else if (number < caseRefuel + casePuncture)
                {
                    Puncture();
                    CalculateDistance();                   
                }
                else if (number < caseRefuel + casePuncture + caseBird)
                {
                    BirdOnWindow();
                    CalculateDistance();                    
                }
                else if (number < caseRefuel + casePuncture + caseBird + caseEngine)
                {
                    EngineBreakDown();
                    CalculateDistance();                    
                }
                else
                {                    
                    Driving();                    
                }
            }
            Console.WriteLine($"\n{Thread.CurrentThread.Name} går i mål!!!");
        }
    }
}
