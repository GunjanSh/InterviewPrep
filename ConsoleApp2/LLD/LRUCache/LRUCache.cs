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
        //Use dequeue to maintain the recently accessed key, where you add latest key to the beginning of the queue.
        LinkedList<int> Cache;

        Dictionary<int, int> CacheDetails;

        public LRUCache(int capacity) 
        {
            this.Cache = new LinkedList<int>();
            this.CacheDetails = new Dictionary<int, int>();

            this.Capacity = capacity;
        }

        public void Add(int key, int value)
        {
            if (this.CacheDetails.Count >= this.Capacity)
            {
                var firstNode = this.Cache.First();
                this.Cache.RemoveFirst();
                this.CacheDetails.Remove(firstNode);
            }

            if (!this.CacheDetails.ContainsKey(key))
            {
                this.CacheDetails[key] = value;
                this.Cache.AddLast(key);
            }
            else
            {
                this.Update(key, value);
            }
        }

        public void Update(int key, int value)
        {
            this.CacheDetails[key] = value;
            this.UpdateRecency(key);
        }

        public int Get(int key)
        {
            if (this.CacheDetails.ContainsKey(key))
            {
                this.UpdateRecency(key);
                return this.CacheDetails[key];
            }

            return -1;
        }

        public void ClearCache()
        {
            this.Cache = new LinkedList<int>();
            this.CacheDetails = new Dictionary<int, int>();
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
