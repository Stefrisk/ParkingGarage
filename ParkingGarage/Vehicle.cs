using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
     public abstract class Vehicle
    {
        public string Type { get; set; }                      
        public  double Size { get; set; }        
        public string Color {  get; set; }                             
        public int RegNum { get; set; }
        public List<int> RegList 
        {
            get { return _regList; } 
            
            set { _regList = value; } 
        }
        private List<int> _regList = new List<int>(); 
        public DateTime ParkedAt { get; set; }

        
        public static void MakeAndParkRandomVehicle(Garage garage)
        {
            
            Random rnd = new Random();
            int rndNum = rnd.Next(1, 4);
            switch (rndNum)
            {
                case 1:
                    Motorcycle motorcycle = new Motorcycle();
                    garage.ParkVehicle(motorcycle, garage);
                    break;



                case 2:
                    Car car = new Car();
                    garage.ParkVehicle(car, garage);
                    break;


                case 3:
                    Buss buss = new Buss();
                    garage.ParkVehicle(buss, garage);
                    break;
                    

            }
            
            

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
