using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD.LRUCache
{
    internal class LRUCache_Caller
    {
        public LRUCache_Caller() { }

        public void TestLruCache()
        {
            int capacity = 5;
            var cache = new LRUCache(capacity);

            cache.Add(1, 1);
            cache.Add(2, 2);
            cache.Add(3, 3);
            cache.Add(4, 4);
            cache.Add(5, 5);

            cache.Get(3);
            cache.Get(1);

            cache.Add(6, 6);
        }
    }
}
