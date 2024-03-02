using ConsoleApp2.LLD;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2.MS
{
    public class RateLimiterExecutor
    {
        public static void Main5(string[] args)
        {
            var obj = new RateLimiterExecutor();

            Task.Run(async () => await obj.TestMethod())
            .ContinueWith(r => {
                if (r.Status == TaskStatus.RanToCompletion)
                {

                }
                else if (r.Status == TaskStatus.Faulted)
                {
                    return;
                }
            });

            var tockenBucket = new TokenBucket(bucketCapacity: 10, refillRate: 10);

            Parallel.For(1, 26, i => {
                var isAllowed = tockenBucket.IsRequestAllowed();
                Console.WriteLine("Request allowed is {0} for thread {1}", isAllowed, i);
                //Thread.Sleep(1000);
            });
        }

        public async Task TestMethod()
        {
            await Task.Delay(1000);
            throw new Exception();
        }

        static Task Print(int idx)
        {
            Console.WriteLine("In thread {0}", idx);
            return Task.CompletedTask;
        }
    }
}
