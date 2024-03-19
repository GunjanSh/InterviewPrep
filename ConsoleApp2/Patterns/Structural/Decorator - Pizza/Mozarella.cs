using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___Pizza
{
    internal class Mozarella : ToppingDecorator
    {
        public Mozarella(IPizza pizza) : base(pizza)
        {
        }

        public override string GetDescription()
        {
            return this.Pizza.GetDescription() + ", Mozarella";
        }

        public override double GetPrice()
        {
            return this.Pizza.GetPrice() + 5;
        }
    }
}
