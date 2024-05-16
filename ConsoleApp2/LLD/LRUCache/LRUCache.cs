using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD.LRUCache
{
    internal class LRUCache
    {
        int Capacity;

        // Double ended queue is implemented by Linked list.
        //Use dequeue to maintain the recently accessed key, where you add latest key to the end of the queue.
        LinkedList<int> Cache;

        Dictionary<int, int> CacheDetailsDict;

        public LRUCache(int capacity) 
        {
            this.Cache = new LinkedList<int>();
            this.CacheDetailsDict = new Dictionary<int, int>();

            this.Capacity = capacity;
        }

        public void Add(int key, int value)
        {
            if (this.CacheDetailsDict.Count >= this.Capacity)
            {
                var firstNode = this.Cache.First();
                this.Cache.RemoveFirst();
                this.CacheDetailsDict.Remove(firstNode);
            }

            if (!this.CacheDetailsDict.ContainsKey(key))
            {
                this.CacheDetailsDict[key] = value;
                this.Cache.AddLast(key);
            }
            else
            {
                this.Update(key, value);
            }
        }

        public void Update(int key, int value)
        {
            this.CacheDetailsDict[key] = value;
            this.UpdateRecency(key);
        }

        public int Get(int key)
        {
            if (this.CacheDetailsDict.ContainsKey(key))
            {
                this.UpdateRecency(key);
                return this.CacheDetailsDict[key];
            }

            return -1;
        }

        public void ClearCache()
        {
            this.Cache = new LinkedList<int>();
            this.CacheDetailsDict = new Dictionary<int, int>();
        }

        //Remove the current key from the queue and add it at the end of the queue.
        void UpdateRecency(int key)
        {
            var node = this.Cache.Find(key);

            if (node != null)
            {
                this.Cache.Remove(node);
                this.Cache.AddLast(node);
            }
        }
    }
}
