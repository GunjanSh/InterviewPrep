using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___CoffeeMaker
{
    internal class Caramel : AddOnDecorator
    {
        public Caramel(Beverage beverage) : base(beverage) 
        {
        
        }

        public override double GetBeverageCost()
        {
            return this.Beverage.GetBeverageCost() + 5;
        }

        public override string GetBeverageName()
        {
            return this.Beverage.GetBeverageName() + ", Caramel";
        }
    }
}
