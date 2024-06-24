using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___ProductBuilder
{
    /*
     * Used to create objects from other objects.
     * 
     * * Lets you construct complex objects step by step. 
     * * The pattern allows you to produce different types and representations of an object using the same construction code.
     * * When you want the creation of these parts to be independent of the main object.
     * * The builder knows the specifics and nobody else.
     * 
     * APPLICABILITY:
     * Use the Builder pattern to get rid of a “telescoping constructor”.
     * Use the Builder pattern when you want your code to be able to create different 
     * representations of some product (for example, stone and wooden houses).
     * Use the Builder to construct Composite trees or other complex objects.
     * 
     */

    internal class ConcreteBuilder : IConcreteBuilder
    {
        IProduct product;

        public ConcreteBuilder(IProduct product)
        {
            this.product = product;
            this.ResetProducts();
        }

        public void BuildPartA()
        {
            this.product.AddProduct("PartA");
        }

        public void BuildPartB()
        {
            this.product.AddProduct("PartB");
        }

        public void BuildPartC()
        {
            this.product.AddProduct("PartC");
        }

        public void BuildPartD()
        {
            this.product.AddProduct("PartD");
        }

        public void GetProduct()
        {
            Console.WriteLine("Product list are: {0}", string.Join(",", this.product.GetProducts()));
        }

        public void ResetProducts()
        {
            this.product.Reset();
        }
    }
}
