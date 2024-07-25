using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Factory
{
    /*
     * Allow creation of objects without exposing creation logic to the client.
     * Interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.
     * 
     * APPLICABILITY:
     * Use the Factory Method when you don’t know beforehand the exact types and dependencies of the objects your code should work with.
     * 
     */

    internal class LawnMowerCatalogFactory : ILawnMowerCatalogFactory
    {
        public ILawnMowerCatalog CreateLawnMowerCatalog(string type)
        {
            return type.ToLower() switch
            {
                "diesel" => new DieselLawnMowerCatalog(),
                "electric" => new ElectricLawnMowerCatalog(),
                _ => new ManualLawnMowerCatalog(),
            };
        }
    }
}
