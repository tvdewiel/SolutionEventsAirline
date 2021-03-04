using System;
using System.Collections.Generic;
using System.Text;

namespace Airline
{
    public class CateringOrder
    {
        public CateringOrder(string airport, int numberOfMeals, DateTime cateringDate)
        {
            Airport = airport;
            NumberOfMeals = numberOfMeals;
            CateringDate = cateringDate;
        }

        public string Airport { get; private set; }
        public int NumberOfMeals { get; private set; }
        public DateTime CateringDate { get; private set; }
        public override string ToString()
        {
            return $"[Order]{Airport};{NumberOfMeals},{CateringDate}";
        }
    }
}
