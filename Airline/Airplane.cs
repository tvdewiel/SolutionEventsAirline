using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineLibrary
{
    public class Airplane
    {
        public Airplane(string name, double fuelCostPerPersonPer100km, int availableSeats, double speed)
        {
            Name = name;
            FuelCostPerPersonPer100km = fuelCostPerPersonPer100km;
            AvailableSeats = availableSeats;
            Speed = speed;
        }

        public string Name { get; private set; }
        public double FuelCostPerPersonPer100km { get; private set; }
        public int AvailableSeats { get; private set; }
        public double Speed { get; private set; }
    }
}
