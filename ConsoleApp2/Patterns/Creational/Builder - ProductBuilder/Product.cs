using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___ProductBuilder
{
    internal class Product : IProduct
    {
        private List<string> list = new List<string>();

        public void AddProduct(string productName)
        {
            this.list.Add(productName);
        }

        public List<string> GetProducts()
        {
            return this.list;
        }

        public void Reset()
        {
            this.list.Clear();
        }
    }
}
