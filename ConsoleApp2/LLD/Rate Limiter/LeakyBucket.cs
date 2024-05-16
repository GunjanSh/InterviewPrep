using ConsoleApp2.MS;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD
{
    //NOTE: This works for a single instance of server.
    //For distributed servers, good to maintain the capacity in a cache or a centralized place.
    //There are no consumers of this queue. In real-world, there will be consumers which will be consuming from the queue.
    //Drawback: Sometimes consumers are not able to consume from queue leading to recent data being lost as the queue is full.
    internal class LeakyBucket : IRateLimiter
    {
        ConcurrentQueue<int> queue;
        int queueCapacity;

        public LeakyBucket(int capacity) 
        {
            this.queueCapacity = capacity;
            this.queue = new ConcurrentQueue<int>() {  };
        }

        public bool IsRequestAllowed()
        {
            if (this.queue.Count < this.queueCapacity)
            {
                Console.WriteLine("Request is allowed");
                this.queue.Enqueue(1); // NOTE: We are adding 1 request to the queue.
                // In case as bulk request is received, you need to accept the number of requests in this method.
                return true;
            }

            Console.WriteLine("Request is not allowed");

            return false;
        }
    }
}
