using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___Pizza
{
    internal class BasePizza : IPizza
    {
        public string GetDescription()
        {
            return "Thin Dough Pizza";
        }

        public double GetPrice()
        {
            return 15;
        }
    }
}
