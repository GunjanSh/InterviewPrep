using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___CoffeeMaker
{
    internal class Cappucino : Beverage
    {
        public Cappucino() 
        {
            this.BeverageName = "Cappucino";
        }

        public override double GetBeverageCost()
        {
            return 20;            
        }
    }
}
