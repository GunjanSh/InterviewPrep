using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___CoffeeMaker
{
    internal class Espresso : Beverage
    {
        public Espresso() 
        {
            this.BeverageName = "Espresso";
        }

        public override double GetBeverageCost()
        {
            return 25;
        }
    }
}
