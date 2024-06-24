using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___ProductBuilder
{
    internal interface IProduct
    {
        void AddProduct(string productName);

        List<string> GetProducts();

        void Reset();
    }
}
