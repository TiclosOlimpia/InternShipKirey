using System;
using System.Collections.Generic;
using System.Text;
using OOPDesignPatternFinalProject.Models;

namespace OOPDesignPatternFinalProject.Taxes
{
    public class TaxByCounty : ITax
    {
        public decimal CalculateTaxes(Customer customer, decimal total)
        {
            decimal tax = 0.0m;

           
                switch (customer.County)
                {
                    case "Travis":
                        tax = total * 0.09m;
                        break;
                    case "Constanta":
                        tax = total * 0.02m;
                        break;
                    default:
                        tax = 0.01m;
                        break;
                }
            Console.WriteLine("tax by county is: " + tax);
            return tax;
        }
    }
}
