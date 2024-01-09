using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Visitor
{
    public class Necessity : IVisitable
    {
        private double Price;

        public Necessity(double Price)
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
