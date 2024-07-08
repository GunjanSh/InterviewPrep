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
            //var output = new List<Tuple<(string type, decimal amount)>>();

            //output.Add(Tuple.Create(("dsad", (decimal)10)));
            //var output = new List<Tuple<string, int>>();
            //output.Add(Tuple.Create("sds", 1));

            return 20;            
        }
    }
}
