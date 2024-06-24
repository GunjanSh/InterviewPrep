using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___Pizza
{
    internal abstract class ToppingDecorator : IPizza
    {
        public IPizza Pizza;

        public ToppingDecorator(IPizza pizza)
        {
            this.Pizza = pizza;
        }

        public virtual string GetDescription()
        {
            return this.Pizza.GetDescription();
        }

        public virtual double GetPrice()
        {
            return this.Pizza.GetPrice();
        }
    }
}
