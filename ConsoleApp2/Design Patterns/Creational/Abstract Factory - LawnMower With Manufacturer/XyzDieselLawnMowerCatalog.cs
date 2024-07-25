using ConsoleApp2.Design_Patterns.Creational.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Abstract_Factory___LawnMower_With_Manufacturer
{
    internal class XyzDieselLawnMowerCatalog : ILawnMowerCatalog
    {
        public LawnMower[] GetLawnMowers()
        {
            return new[] { new LawnMower { Name = "I am a XYZ Diesel Lawn Mower" } };
        }
    }
}
