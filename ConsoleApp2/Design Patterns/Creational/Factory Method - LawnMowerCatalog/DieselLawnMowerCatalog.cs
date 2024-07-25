using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Design_Patterns.Creational.Factory
{
    internal class DieselLawnMowerCatalog : ILawnMowerCatalog
    {
        public LawnMower[] GetLawnMowers()
        {
            return new[] { new LawnMower { Name = "I am a Diesel Lawn Mower" } };
        }
    }
}
