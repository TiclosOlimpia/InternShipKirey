using System;
using System.Collections.Generic;
using System.Text;
using OOPDesignPatternFinalProject.Models;
using OOPDesignPatternFinalProject.Taxes.Interfaces;

namespace OOPDesignPatternFinalProject.Taxes
{
    public class TaxFactory: ITaxFactory
    {
        private Customer _customer;

        public TaxFactory(Customer customer)
        {
            _customer = customer;
        }

        public ITax GetTax()
        {
            if (!string.IsNullOrEmpty(_customer.StateCode))
                return new TaxByState();
            else
                return new TaxByCounty();
        }
    }
}
