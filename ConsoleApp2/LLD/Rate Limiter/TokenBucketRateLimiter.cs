using ConsoleApp2.MS;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD
{
    internal class TokenBucketRateLimiter : IRateLimiter
    {
        //Refill the bucket by refillRate number of tokens.
        int refillRate; //Every minute you need to refill on pro rata basis. This the number of tokens to refill by. 
        int bucketCapacity; //Bucket capacity
        ConcurrentBag<int> currentTokenCounter;
        ConcurrentBag<double> lastUpdatedTime;// We need to refill bucket on pro rata basis.  

        public TokenBucketRateLimiter(int refillRate, int bucketCapacity)
        {
            this.refillRate = refillRate;
            this.bucketCapacity = bucketCapacity;
            this.currentTokenCounter = new ConcurrentBag<int> { bucketCapacity };
            this.lastUpdatedTime = new ConcurrentBag<double> { DateTime.UtcNow.TimeOfDay.TotalMilliseconds };
        }

        public bool IsRequestAllowed()
        {
            lock (this)
            {
                RefreshTokenBucket();
                if (this.currentTokenCounter.TryTake(out var counter) && counter > 0)
                {
                    this.currentTokenCounter.Add(counter - 1);
                    return true;
                }

                return false;
            }
        }

        void RefreshTokenBucket()
        {
            this.lastUpdatedTime.TryTake(out var lastUpdated);
            this.currentTokenCounter.TryTake(out var currentTokens);

            var currTime = DateTime.UtcNow.TimeOfDay.TotalMilliseconds;
            // To get pro rata basis, we check time difference and convert to milliseconds.
            // Followed by multiply by refill rate.
            var additionalTokens = (int) ((currTime - lastUpdated) / 1000) * this.refillRate;

            //Take min of tokens to be added to bucket, else it will waste tokens.
            var tokensToAdd = Math.Min(currentTokens + additionalTokens, this.refillRate);

            this.currentTokenCounter.Add(tokensToAdd);
            this.lastUpdatedTime.Add(currTime);
        }
    }
}
