using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Motorcycle : Vehicle
    {
    public string BrandName {  get; set; }
        public Motorcycle() : base()
        {
            Size = 0.5;
            Color = GenColor();
            RegNum = GenRegNum();
            Type = "Motorcycle";
        }

    }
}
