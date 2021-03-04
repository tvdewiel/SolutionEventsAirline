using System;
using System.Collections.Generic;
using System.Text;

namespace Airline
{
    public class Catering
    {

        public void OnFlightEvent(object source, FlightEventArgs args)
        {
            Console.WriteLine("Catering - onFlightEvent");
            Console.WriteLine(args.Flight);
            PlaceOrder(args.Flight.Route.Departure, args.Flight.SeatsSold);
            Console.WriteLine("----------------");
        }
        public void PlaceOrder(string airport,int numberOfMeals)
        {
            Console.WriteLine($"Ordering {numberOfMeals} meals in {airport}");
        }
    }
}
