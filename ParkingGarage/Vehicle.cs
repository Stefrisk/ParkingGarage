using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
     public class Vehicle
    {
        public string Type { get; set; }
        public double Size { get; set; }
        public string Color  { get; set; }
        public int RegNum { get; set; }
        public List<int> RegList 
        {
            get { return _regList; } 
            
            set { _regList = value; } 
        }
        public List<int> _regList = new List<int>(); 
        public DateTime ParkedAt { get; set; }
        
        
        public static Vehicle MakeRandomVehicle(Garage garage)
        {
            Vehicle vehicle = new Vehicle();
            Random rnd = new Random();
            int rndNum = rnd.Next(1, 4);
            switch (rndNum)
            {
                case 1:
                    Motorcycle motorcycle = new Motorcycle();
                    vehicle = motorcycle;
                    return motorcycle;


                case 2:
                    Car car = new Car();
                    vehicle = car;
                    return car;

                case 3:
                    Buss buss = new Buss();
                    vehicle = buss;
                    return buss;

            }
            
            return vehicle;

        }
        
        public void GenRegNum(List<int> RegList) //makes uniqe reg number 
        {
            int _regNum;
            Random rnd = new Random();
            do
            {
               _regNum = rnd.Next(100000, 999999);

            }
            while (RegList.Contains(_regNum));
            RegList.Add(_regNum);
            RegNum = _regNum;
            
        }
        public void GenColor()
        {
            string[] colors = new string[] { "red", "blue", "yellow", "Green", "Orange", "Pink", "brown", "Teal", "gold", "silver", "polka dot", "diamond", "demasscus" };
            Random rand = new Random();
            Color =  colors[rand.Next(colors.Length)];
        }
    }
}
