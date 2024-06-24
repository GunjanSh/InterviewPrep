using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___ProductBuilder
{
    internal interface IConcreteBuilder
    {
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();

        void BuildPartD();
    }
}
