using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    public class Car : Vehicle
    {
        public bool ElCar { get; set; }    
        public Car() : base()
        {
            Size = 1;
            GenColor();
            GenRegNum(RegList);
            Type = "Car";
            ElCar = GenRandomBool();
        }

        public static bool GenRandomBool()
        {
            Random rnd = new Random();
            bool elcar = rnd.Next(2) == 0;
            return elcar;
        }
        
    }
}
