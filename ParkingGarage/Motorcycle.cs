using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    public class Motorcycle : Vehicle
    {
        public string BrandName { get; set; }
        
        public Motorcycle() : base()
        {

            
            Size = 0.5;
            GenColor();
            GenRegNum(RegList);
            Type = "Motorcycle";
            BrandName = GenBrand();
        }
        public static string GenBrand()
        {
            
            Random rnd = new Random();
            int choice = rnd.Next(1, 6);
            string brand = " ";
            switch (choice)
            {
                case 1:
                    brand =  "Harley";
                    break;
                case 2: brand = "Duccatti";
                    break;
                case 3:
                    brand = "Honda";
                    break;
                case 4:
                    brand = "Kawasaki";
                    break;
                case 5:
                    brand = "Indian";
                    break;
                case 6:
                    brand = "WestCoast Choppers";
                    break;

            }
            
            return brand;
        }


    }
}
