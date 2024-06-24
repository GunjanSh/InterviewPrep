using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.SingletonPattern
{
    public sealed class Singleton3
    {
        private static readonly Singleton3 instance = new Singleton3();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton3()
        {
        }

        private Singleton3()
        {
        }

        public static Singleton3 Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
