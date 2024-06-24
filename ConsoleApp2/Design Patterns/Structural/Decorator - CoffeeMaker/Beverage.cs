using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___CoffeeMaker
{
    internal abstract class Beverage
    {
        public string BeverageName;

        public virtual string GetBeverageName()
        {
            return this.BeverageName;
        }

        public abstract double GetBeverageCost();
    }
}
