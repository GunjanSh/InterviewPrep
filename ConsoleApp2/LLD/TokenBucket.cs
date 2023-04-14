using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.MS
{
    public class TokenBucket : IRateLimiter
    {
        private int bucketCapacity;
        private int refillRate;
        private ConcurrentBag<int> currentCapacity;
        private ConcurrentBag<double> lastUpdatedTime;
        private object lockObj = new object();

        public TokenBucket(int bucketCapacity, int refillRate)
        {
            this.bucketCapacity = bucketCapacity;
            this.refillRate = refillRate;
            this.currentCapacity = new ConcurrentBag<int>() { bucketCapacity };
            this.lastUpdatedTime = new ConcurrentBag<double>() { DateTime.Now.TimeOfDay.TotalMilliseconds };
        }

        public bool IsRequestAllowed()
        {
            lock (lockObj)
            {
                refreshBucket();
                if (this.currentCapacity.TryTake(out int result) && result > 0)
                {
                    this.currentCapacity.Add(result-1);
                    //this.currentCapacity--;
                    return true;
                }

                return false;
            }
        }

        private void refreshBucket()
        {
            //int additionalToken = (int)((currentTime - lastUpdatedTime.get()) / 1000 * refreshRate);
            //int currCapacity = Math.min(currentCapacity.get() + additionalToken, bucketCapacity);

            this.lastUpdatedTime.TryTake(out double lastUpdatedTime);
            this.currentCapacity.TryTake(out int capacity);

            double currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            int additionalTokens = (int)(((currentTime - lastUpdatedTime) / 1000) * this.refillRate);
            var currCapacity = Math.Min(additionalTokens + capacity, this.refillRate);

            //this.currentCapacity = capacity;
            //lastUpdatedTime.getAndSet(currentTime);
            this.currentCapacity.Add(currCapacity);
            this.lastUpdatedTime.Add(currentTime);
        }
    }
}
