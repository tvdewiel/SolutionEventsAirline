using System;
using System.Collections.Generic;
using System.Text;

namespace Airline
{
    public class Finance
    {
        private Dictionary<int,Dictionary<string, List<Flight>>> monthlyFlights = new Dictionary<int,Dictionary<string, List<Flight>>>();
        public void OnFlightEvent(object source, FlightEventArgs args)
        {
            Console.WriteLine("Finance - onFlightEvent");
            Console.WriteLine(args.Flight);
            int year = args.Flight.DepartureDate.Year;
            string month = args.Flight.DepartureDate.ToString("MMMM");
            if (!monthlyFlights.ContainsKey(year))
            {
               monthlyFlights.Add(year, new Dictionary<string, List<Flight>>());
                    //new List<Flight>() { args.Flight });
            }
            if (monthlyFlights[year].ContainsKey(month))
            {
                monthlyFlights[year][month].Add(args.Flight);
            }
            else
            {
                monthlyFlights[year].Add(month, new List<Flight>() { args.Flight });
            }
            Console.WriteLine("----------------");
        }
        private (int,double) CalculateCost(List<Flight> flights)
        {
            double cost = 0;
            foreach(var f in flights)
            {
                cost += f.Cost();
            }
            return (flights.Count, cost);
        }
        public void PrintReport(int year)
        {
            if (monthlyFlights.ContainsKey(year))
            {
                //print all
                foreach(var m in monthlyFlights[year].Keys)
                {
                    Console.WriteLine($"{year},{m},{CalculateCost(monthlyFlights[year][m])}");
                }
            }
        }
    }
}
