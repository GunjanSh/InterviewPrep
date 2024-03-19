using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___CoffeeMaker
{
    internal class CoffeMaker
    {
        public static void PrepareCoffee()
        {
            Beverage beverage = new Cappucino();

            Console.WriteLine(" Name: {0}, Cost: {1} ", beverage.GetBeverageName(), beverage.GetBeverageCost());

            beverage = new Milk(beverage);

            Console.WriteLine("After adding Milk -  Name: {0}, Cost: {1} ", beverage.GetBeverageName(), beverage.GetBeverageCost());

            beverage = new Caramel(beverage);
            beverage = new Caramel(beverage);

            Console.WriteLine("After adding double caramel and milk -  Name: {0}, Cost: {1} ", beverage.GetBeverageName(), beverage.GetBeverageCost());

        }
    }
}
