using System.ComponentModel;

namespace carRentalServiceActivity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car{ brand = "Toyota", colour = "Black", mileage = 158936, numOfDoors = 2, lastServiceDate = new DateOnly(2023, 2, 26), status = CarStatus.Available},
                new Car{ brand = "Ford", colour = "White", mileage = 89653, numOfDoors = 2, lastServiceDate = new DateOnly(2023, 4, 18), status = CarStatus.Available},
                new Car{ brand = "Suzuki", colour = "Red", mileage = 256984, numOfDoors = 4, lastServiceDate = new DateOnly(2023, 8, 5), status = CarStatus.OutForService},
                new Car{ brand = "Nissan", colour = "Gray", mileage = 12598, numOfDoors = 4, lastServiceDate = new DateOnly(2024, 11, 2), status = CarStatus.Available},
                new Car{ brand = "Mahindra", colour = "Blue", mileage = 3651, numOfDoors = 4, lastServiceDate = new DateOnly(2024, 1, 26), status = CarStatus.Booked},
                new Car{ brand = "Hyundai", colour = "Orange", mileage = 157899, numOfDoors = 4, lastServiceDate = new DateOnly(2025, 8, 27), status = CarStatus.OutForService},
                new Car{ brand = "BMW", colour = "Yellow", mileage = 98536, numOfDoors = 2, lastServiceDate = new DateOnly(2026, 2, 7), status = CarStatus.Available},
                new Car{ brand = "Nissan", colour = "Green", mileage = 125874, numOfDoors = 2, lastServiceDate = new DateOnly(2026, 5, 19), status = CarStatus.Booked}
            };

            string filePath = "Report.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {

                writer.WriteLine("--- Car Rental Company Co. Car Report ---\n");
                writer.WriteLine("All cars:");

                foreach (var car in cars)
                {

                    writer.WriteLine($"\tCar: {car.colour} {car.brand}\n\tMileage: {car.mileage} km\n\tNumber of doors: {car.numOfDoors}\n\tDate last serviced: {car.lastServiceDate}\n\tNeeds to be serviced: {car.NeedsToBeServiced()}\n\tCar status for bookings: {car.status}\n");
                }

                var availableCars = cars.Where(c => c.status == CarStatus.Available);
                writer.WriteLine($"Number of available cars for booking: {availableCars.Count()}\n");

                var filteredCarsByDoors = cars.Where(c => c.numOfDoors == 4);
                writer.WriteLine("All cars that have 4 doors:");

                foreach (var car in filteredCarsByDoors)
                {
                    writer.WriteLine($"\tCar: {car.colour} {car.brand}\n\tMileage: {car.mileage} km\n\tNumber of doors: {car.numOfDoors}\n\tDate last serviced: {car.lastServiceDate}\n\tCar status for bookings: {car.status}\n");
                }

                var sortedByYearLastServiced = cars.OrderBy(c => c.lastServiceDate);
                writer.WriteLine("All cars sorted by year last serviced: ");

                foreach (var car in sortedByYearLastServiced)
                {
                    writer.WriteLine($"\tCar: {car.colour} {car.brand}\n\tMileage: {car.mileage} km\n\tNumber of doors: {car.numOfDoors}\n\tDate last serviced: {car.lastServiceDate}\n\tCar status for bookings: {car.status}\n");
                }

                var filteredByBrand = cars.Where(c => c.brand.Equals("Nissan"));
                writer.WriteLine("All Nissans: ");

                foreach (var car in filteredByBrand)
                {
                    writer.WriteLine($"\tCar: {car.colour} {car.brand}\n\tMileage: {car.mileage} km\n\tNumber of doors: {car.numOfDoors}\n\tDate last serviced: {car.lastServiceDate}\n\tCar status for bookings: {car.status}\n");
                }

                writer.WriteLine("--- End of report ---");

            }
        }
    }
}


/*
Create an application for a car rental service
The application should utilise enums to determine if a car is available or booked. 

Include a car class that tracks a rental car's:
  -Brand
  -Colour
  -Mileage
  -How many doors
  -Last serviced (year it was last serviced 
  -Availabilty 

Include an extension method that determined if the car needs to be serviced (assuming a cars needs to be serviced every 2 years)

Populate a list with 8 different types of cars USING Linq to do the following: 
  -Count cars available
  -Filter cars that have 4 doors
  -Sort cars by the year that they were last serviced 
  -Filter the car via brand 
  -Have an application write out a full report to a .txt file
 */