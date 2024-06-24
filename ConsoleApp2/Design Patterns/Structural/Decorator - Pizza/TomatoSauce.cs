using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___Pizza
{
    internal class TomatoSauce : ToppingDecorator
    {
        public TomatoSauce(IPizza pizza) : base(pizza)
        {
        }

        public override string GetDescription()
        {
            return this.Pizza.GetDescription() + ", Tomato sauce";
        }

        public override double GetPrice()
        {
            return this.Pizza.GetPrice() + 2;
        }
    }
}
