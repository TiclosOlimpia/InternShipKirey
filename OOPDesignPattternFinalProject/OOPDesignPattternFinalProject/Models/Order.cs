using System;
using System.Collections.Generic;
using System.Linq;
using OOPDesignPatternFinalProject.Taxes;
using OOPDesignPatternFinalProject.Taxes.Interfaces;

namespace OOPDesignPatternFinalProject.Models
{
    public class Order: IVisitable
    {
        ITaxFactory _taxFactory;
        List<OrderItem> orderItems = new List<OrderItem>();

        public Order(Customer customer) : this(new TaxFactory(customer))
        {

        }


        public Order(ITaxFactory taxFactory)
        {
            _taxFactory = taxFactory;
        }

        public decimal CalculateTotal(Customer customer)
        {
            decimal total = 0.0m;
            
            foreach (var item in orderItems)
            {
                total += item.Cost * item.Quantity;
            }

            //var a = orderItems.Sum((item) =>
            //{
            //    return item.Cost * item.Quantity;
            //});

            ITax tax = _taxFactory.GetTax();
            total += tax.CalculateTaxes(customer, total);

            return total;
        }

        public void AddOrderItem(OrderItem item)
        {
            orderItems.Add(item);
        }

        public void RemoveOrderItem(OrderItem item)
        {
            orderItems.Remove(item);
        }

        public void RemoveOrderAtPosition(int index)
        {
            orderItems.RemoveAt(index);
        }

        public void GetOrderItems()
        {

            foreach (var item in orderItems)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var item in orderItems)
            {
                item.Accept(visitor);
            }
        }
    }
}
