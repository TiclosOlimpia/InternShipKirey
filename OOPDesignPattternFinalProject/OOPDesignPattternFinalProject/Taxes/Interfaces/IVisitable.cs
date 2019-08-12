using System;
using System.Collections.Generic;
using System.Text;

namespace OOPDesignPatternFinalProject.Taxes.Interfaces
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
