using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Garage
    {
        public const double MaxSpots = 15;
        public List<Vehicle> _parkingGarage = new List<Vehicle>();
        public double availableSpots = MaxSpots;
        public List<Vehicle> ParkingGarage
        {
            get { return _parkingGarage; }
            set { _parkingGarage = value; }
        }
        public Garage()
        {

        }

        public void PrintGarage(Garage garage)
        {
            for (int i = 0; i < garage.ParkingGarage.Count;)
            {
                Console.WriteLine(garage.ParkingGarage[i].RegNum);
                Console.WriteLine(garage.ParkingGarage[i].Color);
                Console.WriteLine();
            }
        }
        public void SortGarage(Garage garage)
        {
            double Cars = 0;
            double Buss = 0;
            double MC = 0;
            foreach (Vehicle v in ParkingGarage)
            {
                if (v.Type == "C")
                {
                    Cars++;
                }
                else if (v.Type == "B")
                {
                    Buss++;
                }
                else if (v.Type == "M")
                {
                    MC++;
                }
            }
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            if (availableSpots >= vehicle.Size) 
            {
                _parkingGarage.Add(vehicle);
                availableSpots -= vehicle.Size;
                Console.WriteLine($"{vehicle.GetType().Name}Added! Spots left:{availableSpots}");
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

