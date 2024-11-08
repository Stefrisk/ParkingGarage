﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Buss : Vehicle
    {
        public int AmountofPassengers {  get; set; }
        public Buss() : base()
        {
            Size = 2;
            Color = GenColor();
            RegNum = GenRegNum();
            Type = "Buss";
            AmountofPassengers = SetPassengers();
        }
        public int SetPassengers()
        {
            Random rnd = new Random();
            int p = rnd.Next(0, 20);

            return p;

        }
    }
   
}
