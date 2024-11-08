using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Garage
    {
        public int CarsInGarage { get; set; }
        public int McInGarage {  get; set; }
        public int BussInGarage { get; set; }
        public const double MaxSpots = 15;
        public double availableSpots = MaxSpots;
        public double SpotsTaken
        {
            get { return MaxSpots - availableSpots; }

        }    
        public Dictionary<int, List<Vehicle>> _parkingGarage = new Dictionary<int, List<Vehicle>>();

        public Dictionary<int, List<Vehicle>> ParkingGarage 
        {
            get { return _parkingGarage; }
            set { _parkingGarage = value; } 
        }
        
        
        public Garage()
        {

        }

        public void PrintGarage(Garage garage)
        {
            

            for (int i = 0;i < ParkingGarage.Count; i++)
            {
                Console.WriteLine("____________________________");
                Console.WriteLine("Parking Spot" + (i+1) + ":");
                foreach (Vehicle v in ParkingGarage[i])
                {
                    Console.WriteLine("Time parked: " + v.ParkedAt.ToString());
                    Console.WriteLine(v.RegNum);
                    Console.WriteLine(v.Color);
                    if (v is Car car) 
                    {
                        Console.WriteLine("El car: " + car.ElCar.ToString());
                            
                    }
                    if (v is Buss buss)
                    {
                        Console.WriteLine("Amount of passengers: " + buss.AmountofPassengers);
                    }
                    if(v is Motorcycle motorcycle)
                    {
                        Console.WriteLine("Motorcycle brand name: " + motorcycle.BrandName);
                    }

                    Console.WriteLine();
                    
                }

            }
            
        }
        public void SortGarage(Garage garage)
        {
            garage.availableSpots = 15;
            int Cars = 0;
            int  MC = 0;
            int Buss = 0;
            for (int i = 0; i < 14; i++) 
            {
                foreach (Vehicle v in ParkingGarage[i])
                {
                    garage.availableSpots -= v.Size;
                    if (v is Car)
                    {

                        Cars++;
                    }
                    else if (v is Buss)
                    {
                        Buss++;
                    }
                    else if (v is Motorcycle)
                    {
                        MC++;
                    }
                }



            }
            
            CarsInGarage = Cars;
            BussInGarage = Buss;
            McInGarage = MC;
            garage.availableSpots -= CarsInGarage + (McInGarage * 0.5) + (BussInGarage * 2);

        }
        public bool AddVehicle(Vehicle vehicle)
        {
            if (availableSpots >= vehicle.Size) 
            {
                if (vehicle is Car car)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        if (ParkingGarage[i].Contains(null) == true)
                        {
                            vehicle.ParkedAt = DateTime.Now;
                            ParkingGarage[i].Add(car);
                            availableSpots -= car.Size;
                            Console.WriteLine($"{car.GetType().Name}Added! Spots left:{availableSpots}");
                            return true;

                        }
                        
                    }

                }
                if(vehicle is Buss)
                {
                    for (int i = 0;i < 14; i++)
                    {
                        if(ParkingGarage[i].Contains(null) == true&& ParkingGarage[i+1].Contains(null) == true)
                        {

                        }
                    }
                }
                return true;

            } 
            else
            {
                Console.WriteLine("The garage is full at the moment!");
                return false;
            }

        }
    }
}

