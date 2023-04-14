using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Visitor
{
    public class TaxHolidayVisitor : IVisitor
    {
        public double Visit(Necessity obj)
        {
            Console.WriteLine("From Necessity tax visitor");
            return obj.GetPrice() * .10;
        }

        public double Visit(Tobacco obj)
        {
            Console.WriteLine("From Tobacco tax visitor");
            return obj.GetPrice() * .25;
        }
    }
}
