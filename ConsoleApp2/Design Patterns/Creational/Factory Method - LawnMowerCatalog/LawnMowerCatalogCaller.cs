using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Factory
{
    internal class LawnMowerCatalogCaller
    {
        internal static void GetCatalogDetails()
        {
            var catalogCreator = new LawnMowerCatalogFactory();

            var catalog = catalogCreator.CreateLawnMowerCatalog("Diesel");
            Console.WriteLine(string.Join(",", catalog.GetLawnMowers().Select(x => x.Name)));

            catalog = catalogCreator.CreateLawnMowerCatalog(string.Empty);
            Console.WriteLine(string.Join(",", catalog.GetLawnMowers().Select(x => x.Name)));

            catalog = catalogCreator.CreateLawnMowerCatalog("Electric");
            Console.WriteLine(string.Join(",", catalog.GetLawnMowers().Select(x => x.Name)));

            catalog = catalogCreator.CreateLawnMowerCatalog("Manual");
            Console.WriteLine(string.Join(",", catalog.GetLawnMowers().Select(x => x.Name)));
        }
    }
}
