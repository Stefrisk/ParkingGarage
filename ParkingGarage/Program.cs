using System.ComponentModel.Design;

namespace ParkingGarage
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int choice = 0;
            bool menu = true;
            Garage parkingGarage = new Garage();
            parkingGarage.PopulateGarage(parkingGarage);
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Parking Garage!\n1) Check in\n2) Print garage\n3)Checkout\n4)End program");
                Console.WriteLine($"Available spots: {parkingGarage.availableSpots}  Cars: {parkingGarage.CarsInGarage}  MC: {parkingGarage.McInGarage} Bus: {parkingGarage.BussInGarage} Spots taken: {parkingGarage.SpotsTaken}");
                Int32.TryParse(Console.ReadLine(), out choice);
               

                switch (choice)
                {
                    case 1:
                        Vehicle.MakeAndParkRandomVehicle(parkingGarage);
                        break;
                    case 2:
                        parkingGarage.PrintGarage(parkingGarage);
                        Console.ReadLine();
                        break;
                    case 3:
                        parkingGarage.Checkout(parkingGarage);
                        break;
                    case 4:
                        menu = false;
                        break;



                }

            }

        }
    }
}
