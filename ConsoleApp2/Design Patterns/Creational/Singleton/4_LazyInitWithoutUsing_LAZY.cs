using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.SingletonPattern
{
    public sealed class Singleton4
    {
        private Singleton4()
        {
        }

        public static Singleton4 Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Singleton4 instance = new Singleton4();
        }
    }
}
