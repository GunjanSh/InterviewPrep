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

            // Task.Factory.StartNew(, TaskCreationOptions.LongRunning);
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            var task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task Cancelled");
                        return;
                    }

                    Task.Delay(100);
                }

                Console.WriteLine("Task Completed");
            }, token);

            cts.Cancel();

            task.Wait(token);

            using var cts2 = new CancellationTokenSource();
            var token2 = cts2.Token;

            var task2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    token.ThrowIfCancellationRequested();

                    Task.Delay(100);
                }

                Console.WriteLine("Task Completed");
            }, token2);

            try
            {
                task2.Wait(token2);
            }
            catch (OperationCanceledException ex) 
            {
                Console.WriteLine(ex.Message);
            }

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
