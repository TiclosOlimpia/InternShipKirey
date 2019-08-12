
using OOPDesignPatternFinalProject.Taxes.Interfaces;

namespace OOPDesignPatternFinalProject.Models
{
    public class OrderItem : IVisitable
    {
        public int Quantity { get; set; }
        public string Code { get; set; }
        public decimal Cost { get; set; }

        public OrderItem(int quantity, string code, decimal cost)
        {
            Quantity = quantity;
            Code = code;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"cantitate: {Quantity}, cod: {Code}, cost:{Cost}";
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
