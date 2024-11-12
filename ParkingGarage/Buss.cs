using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    public class Buss : Vehicle
    {
        public int AmountofPassengers {  get; set; }
        public Buss() : base()
        {
            Size = 2;
            GenColor();
            GenRegNum(RegList);
            Type = "Buss";
            AmountofPassengers = SetPassengers();
        }
        public static int SetPassengers()
        {
            Random rnd = new Random();
            int p = rnd.Next(0, 20);

            return p;

        }
    }
   
}
