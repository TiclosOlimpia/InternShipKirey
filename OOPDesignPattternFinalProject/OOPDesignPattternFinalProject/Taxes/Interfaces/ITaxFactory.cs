using System;
using System.Collections.Generic;
using System.Text;

namespace OOPDesignPatternFinalProject.Taxes.Interfaces
{
    public interface ITaxFactory
    {
        /// <summary>
        /// Access taxes 
        /// </summary>
        /// <returns></returns>
        ITax GetTax();
    }
}
