
using OOPDesignPatternFinalProject.Models;

namespace OOPDesignPatternFinalProject.Taxes
{
    public interface ITax
    {
        /// <summary>
        /// calculates taxes for total order item 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        decimal CalculateTaxes(Customer customer, decimal total);
    }
}
