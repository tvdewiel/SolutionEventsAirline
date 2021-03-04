using System;
using System.Collections.Generic;
using System.Text;

namespace Airline
{
    public class Finance
    {
        private Dictionary<int,Dictionary<string, List<Flight>>> monthlyFlights = new Dictionary<int,Dictionary<string, List<Flight>>>();//year/month/...
        private Dictionary<int, Dictionary<string, Dictionary<string, List<CateringOrder>>>> monthlyCatering = new Dictionary<int, Dictionary<string, Dictionary<string, List<CateringOrder>>>>();        public void OnFlightEvent(object source, FlightEventArgs args)
        {
            Console.WriteLine("Finance - onFlightEvent");
            Console.WriteLine(args.Flight);
            int year = args.Flight.DepartureDate.Year;
            string month = args.Flight.DepartureDate.ToString("MMMM");
            if (!monthlyFlights.ContainsKey(year))
            {
               monthlyFlights.Add(year, new Dictionary<string, List<Flight>>());
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
        private (int,double) CalculateFuelCost(List<Flight> flights)
        {
            double cost = 0;
            foreach(var f in flights)
            {
                cost += f.Cost();
            }
            return (flights.Count, cost);
        }
        public void PrintFuelReport(int year)
        {
            if (monthlyFlights.ContainsKey(year))
            {
                foreach(var m in monthlyFlights[year].Keys)
                {
                    Console.WriteLine($"{year},{m},{CalculateFuelCost(monthlyFlights[year][m])}");
                }
            }
        }
        public void OnCateringEvent(object source, CateringEventArgs args)
        {
            Console.WriteLine("Finance - onCateringEvent");
            Console.WriteLine(args.Flight);
            int year = args.Flight.DepartureDate.Year;
            string month = args.Flight.DepartureDate.ToString("MMMM");
            string airport = args.Order.Airport;
            if (!monthlyCatering.ContainsKey(year))
            {
                monthlyCatering.Add(year, new Dictionary<string, Dictionary<string, List<CateringOrder>>>());
            }
            if (!monthlyCatering[year].ContainsKey(month))
            {
                monthlyCatering[year].Add(month, new Dictionary<string, List<CateringOrder>>());
            }
            if (!monthlyCatering[year][month].ContainsKey(airport))
            {
                monthlyCatering[year][month].Add(airport, new List<CateringOrder>());
            }

            monthlyCatering[year][month][airport].Add(args.Order);

            Console.WriteLine("----------------");
        }
    }
}
