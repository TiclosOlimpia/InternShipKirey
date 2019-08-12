
using System;
using System.Collections;
using System.Collections.Generic;
using OOPDesignPatternFinalProject.Models;
using OOPDesignPatternFinalProject.Taxes.Interfaces;

namespace OOPDesignPatternFinalProject.Discount
{
    public class DiscountVisitor: IVisitor, IObservable
    {
        private decimal _procent;
        private IList<IObserver> _observers = new List<IObserver>();

        public void SetDiscount(decimal procent)
        {
            _procent = procent;
        }

        public decimal GetDiscount()
        {
            return _procent;
        }

        public DiscountVisitor(decimal procent)
        {
            SetDiscount(procent);
        }
        public void Visit(IVisitable visitable)
        {
            var orderItem = visitable as OrderItem;

            orderItem.Cost -= orderItem.Cost * _procent;
            Notify();
            Console.WriteLine("noul cost dupa aplicarea discountului este:"+orderItem.Cost);
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var item in _observers)
            {
                item.Update(this);
            }
        }
    }
}
