using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    public class ParkingSpot: Garage
    {
        public int SpotNumber { get; set; }
        public bool Taken { get; set; }
        public List<Vehicle> _parkingSpot = new List<Vehicle>();
        public List<Vehicle> ParkSpot 
        {
            get { return _parkingSpot;  } 
            set {  _parkingSpot = value;  }
        }
        public ParkingSpot(int spotnumber) 
        {
            Taken = false;
            SpotNumber = spotnumber;

        }
    }
}
