using ConsoleApp2.Design_Patterns.Creational.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Abstract_Factory___LawnMower_With_Manufacturer
{
    /*
     * Allows a layer of abstraction over other factory classes.
     * Lets you produce families of related objects without specifying their concrete classes.
     * 
     * APPLICABILITY
     * Use the Abstract Factory when your code needs to work with various families of related products, 
     * but you don’t want it to depend on the concrete classes of those products—they might be unknown 
     * beforehand or you simply want to allow for future extensibility.
     * 
     * 
     */

    internal class LawnMowerCatalogAbstractFactory : ILawnMowerCatalogAbstractFactory
    {
        public ILawnMowerCatalogFactory CreateCatalog(string manufacturer)
        {
            return manufacturer.ToLower() switch
            { 
                "xyz" => new XyzLawnMowerCatalogFactory(),
                _ => new LawnMowerCatalogFactory(),
            };
        }
    }
}
