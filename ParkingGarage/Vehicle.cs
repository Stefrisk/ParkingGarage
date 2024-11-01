using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    internal class Vehicle
    {
        public string Type { get; set; }
        public double Size { get; set; }
        public string Color { get; set; }
        public int RegNum { get; set; }
        public Vehicle()
        {
            RegNum = GenRegNum();
            Color = GenColor();
        }

        public static int GenRegNum()
        {
            Random rnd = new Random();
            int RegNum = rnd.Next(10000, 99999);
            return RegNum;
        }
        public static string GenColor()
        {
        string[] colors = new string[] { "red", "blue", "yellow", "Green", "Orange", "Pink", "brown", "Teal", "gold", "silver", "polka dot", "diamond" };
        Random rand = new Random();
            return colors[rand.Next(colors.Length)];
        }
    }
}
