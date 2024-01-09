using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___ProductBuilder
{
    internal class Director
    {
        IConcreteBuilder builder;

        public Director(IConcreteBuilder builder)
        {
            this.builder = builder;
        }

        internal void MinimalViableProduct()
        {
            this.builder.BuildPartA();
            this.builder.BuildPartB();
            this.builder.BuildPartC();
        }

        internal void FullProduct()
        {
            this.builder.BuildPartA();
            this.builder.BuildPartB();
            this.builder.BuildPartC();
            this.builder.BuildPartD();
        }
    }
}
