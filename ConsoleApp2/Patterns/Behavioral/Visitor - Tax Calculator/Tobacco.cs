using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Visitor
{
    public class Tobacco : IVisitable
    {
        private double Price;

        public Tobacco(double Price)
        {
            this.Price = Price;
        }

        public double GetPrice()
        {
            return Price;
        }

        public double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
