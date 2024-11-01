using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Garage
    {
        public Vehicle[] _parkingGarage = new Vehicle[15];
        public Vehicle[] ParkingGarage
        {
            get { return _parkingGarage; }
            set { _parkingGarage = value; }
        }
        public Garage()
        {

        } 
        
        public void PrintGarage(Garage garage)
        {
            for(int i = 0; i < garage.ParkingGarage.Length;)
            {
                Console.WriteLine(garage.ParkingGarage[i].RegNum);
                Console.WriteLine(garage.ParkingGarage[i].Color);

            }
        }
        }
    }
}
