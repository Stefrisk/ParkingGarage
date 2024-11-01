using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Car : Vehicle
    {
        public bool ElCar { get; set; }    
        public Car() : base()
        {
            Size = 1;
            Color = GenColor();
            RegNum = GenRegNum();
            Type = "Car";
        }
    }
}
