using System;
using System.Collections.Generic;
using System.Text;

namespace carRentalServiceActivity
{
    class Car
    {
        public string brand { get; set; }
        public string colour { get; set; }
        public int mileage { get; set; }
        public int numOfDoors { get; set; }
        public DateOnly lastServiceDate { get; set; }
        public CarStatus status { get; set; }

        public bool NeedsToBeServiced()
        {
            return (2026 - lastServiceDate.Year) >= 2;
        }
    }
}
