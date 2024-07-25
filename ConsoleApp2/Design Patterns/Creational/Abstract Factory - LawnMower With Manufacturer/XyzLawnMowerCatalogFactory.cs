using ConsoleApp2.Design_Patterns.Creational.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Abstract_Factory___LawnMower_With_Manufacturer
{
    internal class XyzLawnMowerCatalogFactory : ILawnMowerCatalogFactory
    {
        public ILawnMowerCatalog CreateLawnMowerCatalog(string type)
        {
            return type.ToLower() switch
            {
                "diesel" => new XyzDieselLawnMowerCatalog(),
                "electric" => new XyzElectricLawnMowerCatalog(),
                _ => new XyzManualLawnMowerCatalog(),
            };
        }
    }
}
