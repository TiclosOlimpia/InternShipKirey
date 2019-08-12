using System;
using System.Collections.Generic;
using System.Text;
using OOPDesignPatternFinalProject.Taxes.Interfaces;

namespace OOPDesignPatternFinalProject.Discount
{
    public class DiscountObserver: IObserver
    {
        public decimal DiscountAccepted { get; set; }

        public DiscountObserver(decimal discountProcente)
        {
            DiscountAccepted = discountProcente;
        }
        public void Update(IObservable observable)
        {
            var discountVisitor = observable as DiscountVisitor;
            if (discountVisitor.GetDiscount() >= DiscountAccepted)
            {
                Console.WriteLine("Discount is ok");
            }
            else
            {
                Console.WriteLine("Discount is not accepted");
            }
        }
    }
}
