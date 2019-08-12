using System;
using OOPDesignPatternFinalProject.Discount;
using OOPDesignPatternFinalProject.Models;
using OOPDesignPatternFinalProject.Taxes;

namespace OOPDesignPatternFinalProject
{
    class Program
    {
        private static object _taxFactory;

        static void Main(string[] args)
        {
            var customer1 = new Customer("", "435678", "Brasov");
            var customer2 = new Customer("Ro", "224322", "Mamaia");
            var customer3 = new Customer("Am", "dfnsdf", "Constanta");

            var orderItem1 = new OrderItem(12, "Tx", 4.5m);
            var orderItem2 = new OrderItem(25, "Ro", 3.5m);
            var orderItem3 = new OrderItem(55, " ", 6.25m);

            var order = new Order(customer1);

            order.AddOrderItem(orderItem1);
            order.AddOrderItem(orderItem2);
            order.AddOrderItem(orderItem3);

            order.GetOrderItems();

            var discount = new DiscountVisitor(0.2m);

            discount.Visit(orderItem1);
            Console.WriteLine("totalul pentru customer1 este {0}",order.CalculateTotal(customer1));

            var discountObserver = new DiscountObserver(0.3m);

            discountObserver.Update(discount);
            discount.Attach(discountObserver);

            discount.Notify();
        }
    }
}
