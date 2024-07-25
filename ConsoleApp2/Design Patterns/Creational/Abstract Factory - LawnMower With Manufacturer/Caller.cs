using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Abstract_Factory___LawnMower_With_Manufacturer
{
    internal class Caller
    {
        internal static void GetCatalog()
        {
            var abstractFactory = new LawnMowerCatalogAbstractFactory();

            var factory = abstractFactory.CreateCatalog("xyz").CreateLawnMowerCatalog("diesel");
            Console.WriteLine(string.Join(",", factory.GetLawnMowers().Select(x => x.Name)));

            factory = abstractFactory.CreateCatalog("xyz").CreateLawnMowerCatalog("electric");
            Console.WriteLine(string.Join(",", factory.GetLawnMowers().Select(x => x.Name)));

            factory = abstractFactory.CreateCatalog("xyz").CreateLawnMowerCatalog(string.Empty);
            Console.WriteLine(string.Join(",", factory.GetLawnMowers().Select(x => x.Name)));

            factory = abstractFactory.CreateCatalog(string.Empty).CreateLawnMowerCatalog("diesel");
            Console.WriteLine(string.Join(",", factory.GetLawnMowers().Select(x => x.Name)));

            factory = abstractFactory.CreateCatalog(string.Empty).CreateLawnMowerCatalog(string.Empty);
            Console.WriteLine(string.Join(",", factory.GetLawnMowers().Select(x => x.Name)));
        }
    }
}
