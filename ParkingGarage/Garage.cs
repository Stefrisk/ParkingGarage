using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage
{
    public class Garage
    {
        public int CarsInGarage { get; set; }
        public int McInGarage { get; set; }
        public int BussInGarage { get; set; }
        private const double MaxSpots = 15; 
        public double availableSpots = MaxSpots;
        public double SpotsTaken
        {
            get { return MaxSpots - availableSpots; }

        }
        private List<ParkingSpot> _parkingGarage = new List<ParkingSpot>();

        public List<ParkingSpot> ParkingGarage
        {
            get { return _parkingGarage; }
            set { _parkingGarage = value; }
        }


        public Garage()
        {

        }
        public void PopulateGarage(Garage garage) 
        {
            for (int i = 1; i <= 15; i++) // creates 15 empty parkingspots in ParkingGarage when new instance of Garage is made 
            {
                ParkingSpot parkingspot = new ParkingSpot(i);
                ParkingGarage.Add(parkingspot);

            }
        }

        public void PrintGarage(Garage garage)
        {


            for (int i = 0; i < ParkingGarage.Count; i++)
            {

                Console.WriteLine("____________________________________________________________________");
                Console.WriteLine("Parking Spot " + (i + 1));
                foreach (Vehicle v in ParkingGarage[i].ParkSpot)
                {
                    Console.WriteLine("Time parked: " + v.ParkedAt.ToString());
                    Console.WriteLine($"{v.Type} : {v.RegNum}");
                    Console.WriteLine(v.Color);
                    if (v is Car car)
                    {
                        Console.WriteLine($"El car: " + car.ElCar.ToString());

                    }
                    if (v is Buss buss)
                    {
                        Console.WriteLine($"Amount of passengers: " + buss.AmountofPassengers);
                    }
                    if (v is Motorcycle motorcycle)
                    {
                        Console.WriteLine($"Motorcycle brand name: " + motorcycle.BrandName);
                    }

                    Console.WriteLine();

                }

            }

        }
        public void CountGarage(Garage garage) // counts vehcles in garage to update menu counter and provide info to ParkVehicle 
        {
            garage.availableSpots = 15;
            int Cars = 0;
            int MC = 0;
            int Buss = 0;
            for (int i = 0; i < ParkingGarage.Count ; i++)
            {
                foreach (Vehicle v in ParkingGarage[i].ParkSpot)
                {

                    if (v is Car)
                    {

                        Cars++;
                    }
                    else if (v is Buss)
                    {
                        Buss++;
                        i++;
                    }
                    else if (v is Motorcycle)
                    {
                        MC++;
                    }
                }



            }

            CarsInGarage = Cars;
            BussInGarage = Buss;  // update counters 
            McInGarage = MC;
            garage.availableSpots -= (CarsInGarage + (McInGarage * 0.5) + (BussInGarage * 2)); // calculate free spots 

        }
        public bool ParkVehicle(Vehicle vehicle, Garage garage)
        {
            CountGarage(garage); // updates vehicle count
            if (availableSpots >= vehicle.Size) // will only park vehicle if there are avaiable spots, value has to be updated before parking new vehicle
            {
                if (vehicle is Car car)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (ParkingGarage[i].ParkSpot.Count == 0)
                        {
                            car.ParkedAt = DateTime.Now;
                            ParkingGarage[i].ParkSpot.Add(car);
                            ParkingGarage[i].Taken = true;
                            availableSpots -= car.Size;
                            Console.WriteLine($"{car.Color} {car.GetType().Name} added! Spots left:{availableSpots}");
                            CountGarage(garage);
                            Console.ReadLine();
                            return true;

                        }
                        

                    }

                }
                else if (vehicle is Buss buss) 
                {

                    for (int i = 0; i < 15; i++)
                    {

                        if (ParkingGarage[i].ParkSpot.Count == 0 && ParkingGarage[i + 1].ParkSpot.Count == 0)
                        {
                            buss.ParkedAt = DateTime.Now;
                            ParkingGarage[i].ParkSpot.Add(buss);
                            ParkingGarage[i + 1].ParkSpot.Add(buss);
                            ParkingGarage[i].Taken = true;
                            availableSpots -= buss.Size;
                            Console.WriteLine($"A {buss.Color} {buss.Type} with {buss.AmountofPassengers} passengers was added! Spots left: {availableSpots}");
                            CountGarage(garage);
                            Console.ReadLine();
                            return true;
                        }
                        
                    }
                    
                }
                else if (vehicle is Motorcycle motorcycle)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        bool mcParkedHere = ParkingGarage[i].ParkSpot.Count == 1 &&
                            ParkingGarage[i].ParkSpot[0].GetType() == typeof(Motorcycle);

                        if (mcParkedHere == true)
                        {


                            motorcycle.ParkedAt = DateTime.Now;
                            ParkingGarage[i].ParkSpot.Add(motorcycle);
                            ParkingGarage[i].Taken = true;
                            availableSpots -= motorcycle.Size;
                            Console.WriteLine($"A {motorcycle.Color} {motorcycle.BrandName} motorcycle added! Spots left: {availableSpots}");
                            CountGarage(garage);
                            Console.ReadLine();
                            return true;


                        }
                        else if (ParkingGarage[i].ParkSpot.Count == 0)
                        {
                            motorcycle.ParkedAt = DateTime.Now;
                            ParkingGarage[i].ParkSpot.Add(motorcycle);
                            ParkingGarage[i].Taken = true;
                            availableSpots -= motorcycle.Size;
                            Console.WriteLine($"A {motorcycle.Color} {motorcycle.BrandName} motorcycle added! Spots left: {availableSpots}");
                            CountGarage(garage);
                            Console.ReadLine();
                            return true;
                        }
                         
                            

                    }
                   
                }
                


            }
            
                Console.WriteLine("The garage is full at the moment!");
                Console.ReadLine();
                return false;
        }
       
        public void Checkout(Garage garage)
        {
            PrintGarage(garage);
            Console.WriteLine("Write the spot # of the vehicle you would like to checkout: ");
            Int32.TryParse(Console.ReadLine(), out int choice); // read user choice 
            
            if (choice < ParkingGarage.Count + 1 && choice > 0 && ParkingGarage[choice -1].ParkSpot.Count > 0)
            {
                DateTime now = DateTime.Now;                                                        // gets the differnce in time between now and when vehicle was parked to give us the total duration of time parked 
                TimeSpan parkDuration = now - ParkingGarage[choice - 1].ParkSpot[0].ParkedAt;
                double minsParked = parkDuration.Minutes;
                double fee = minsParked * 1.5;                                                      // Calculates parking fee 

                bool containsCar = ParkingGarage[choice - 1].ParkSpot.Count == 1 && ParkingGarage[choice - 1].ParkSpot[0].GetType() == typeof(Car); // checks parking spot for Car
                bool containsBus = ParkingGarage[choice - 1].ParkSpot.Count == 1 && ParkingGarage[choice - 1].ParkSpot[0].GetType() == typeof(Buss); // checks spot for bus
                bool alsoContainsBus = ParkingGarage[choice - 1].ParkSpot.Count == 1 && ParkingGarage[choice - 1].ParkSpot[0].GetType() == typeof(Buss);   // checks neighbors spot for bus                                                                                                                           // checks parking spot for Bus
                bool containsMC = ParkingGarage[choice - 1].ParkSpot.Count == 1 && ParkingGarage[choice - 1].ParkSpot[0].GetType() == typeof(Motorcycle);
                if (ParkingGarage[choice - 1].ParkSpot.Count == 2 )  // comes in if there are 2 vehcles , only time there are 2 vehcles are when there are 2 motorcycles parked 
                {
                    Console.WriteLine("Which motorcycle would you like to checkout?: "); 
                    int j = 1;
                    foreach (Motorcycle m in ParkingGarage[choice - 1].ParkSpot)
                    {
                        Console.WriteLine("Motorcycle: " + (j) + " " + m.RegNum + " " + m.Color + " " + m.BrandName);
                        j++;
                    }
                    Int32.TryParse(Console.ReadLine(), out int choice2); // read user input
                    ParkingGarage[choice - 1].ParkSpot.RemoveAt(choice2 - 1);
                    Console.WriteLine($"Motorcycle checked out succesfully! Your fee is {fee}kr  |  Press enter to return to menu: ");

                }
                else if (containsMC) // comes in if parkingspot contains 1 mc 
                {
                    availableSpots += 0.5;
                    ParkingGarage[choice - 1].ParkSpot.Clear();
                    Console.WriteLine($"Motorcycle checked out succesfully! Your fee is {fee}kr  |  Press enter to return to menu: ");
                }
                else if (containsCar) // if contains 1 car 
                {
                    availableSpots += 1;
                    ParkingGarage[choice - 1].ParkSpot.Clear();
                    Console.WriteLine($"Car checked out succesfully! Your fee is {fee}kr  |  Press enter to return to menu: ");

                }
                else if (containsBus && alsoContainsBus && ParkingGarage[choice - 1].ParkSpot[0] == ParkingGarage[choice].ParkSpot[0]) // checks for buss in both spots and makes sure they are same bus
                {                   
                    availableSpots += 2;
                    ParkingGarage[choice - 1].ParkSpot.Clear();
                    ParkingGarage[choice].ParkSpot.Clear();
                    Console.WriteLine($"Bus checked out succesfully! Your fee is {fee}kr  |  Press enter to return to menu: ");

                }
                else
                    Console.WriteLine("Something went wrong. Press Enter to return to menu:");


            }
            else
            {

                Console.WriteLine("Something went wrong. Press Enter to return to menu: ");

            }


            Console.ReadLine();
        }

    }
}

