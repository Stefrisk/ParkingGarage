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
        public string BrandName
        {
            get { return BrandName; }
            set { BrandName = value; }
        }
        public Motorcycle() : base()
        {

            BrandName = Console.ReadLine();
            Size = 0.5;
            Color = GenColor();
            RegNum = GenRegNum();
            Type = "Motorcycle";
            BrandName = GenBrand();
        }
        public string GenBrand()
        {
            string Brand = " ";
            Random rnd = new Random();
            int brand = rnd.Next(1, 6);
            switch (brand)
            {
                case 1: Brand = "Harley";
                    break;
                case 2:Brand = "Duccatti";
                    break;
                case 3:Brand = "Honda";
                    break;
                case 4: Brand = "Kawasaki";
                    break;
                case 5:
                    Brand = "Indian";
                    break;
                case 6:
                    Brand = "WestCoast Choppers";
                    break;

            }
            return Brand;
        }


    }
}
