using System;
using OOPDesignPatternFinalProject.Models;

namespace OOPDesignPatternFinalProject.Taxes
{
    public class TaxByState : ITax
    {
        public decimal CalculateTaxes(Customer customer, decimal total)
        {
            decimal tax = 0.0m;


            switch (customer.StateCode)
            {
                case "Tx":
                    tax = total * 0.08m;
                    break;
                case "Ro":
                    tax = total * 0.05m;
                    break;
                default:
                    tax = 0.01m;
                    break;
            }

            Console.WriteLine("tax by state is: "+tax);

            return tax;
        }

       
    }
}
