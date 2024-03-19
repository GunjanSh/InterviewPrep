using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___CoffeeMaker
{
    internal abstract class AddOnDecorator : Beverage
    {
        public Beverage Beverage;

        public AddOnDecorator(Beverage beverage)
        {
            Beverage = beverage;
        }

        public override string GetBeverageName()
        {
            return this.Beverage.GetBeverageName();
        }

        public override double GetBeverageCost()
        {
            return this.Beverage.GetBeverageCost();
        }

    }
}
