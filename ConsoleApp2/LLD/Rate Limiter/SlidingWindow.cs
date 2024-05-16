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
    /*
     *  We have a sliding window and allow requests within capacity and within the time frame defined.
     *  Before granting, also remove old requests which are not within the current time frame (say 1 minute).
     */

    internal class SlidingWindow : IRateLimiter
    {
        ConcurrentQueue<double> queue;
        int queueCapacity; // Queue capacity to limit the requests coming in
        double timeInCurrentWindow; // Allow requests in queue within the last time window.

        public SlidingWindow(int capacity, double timeInWindow)
        {
            this.queueCapacity = capacity;
            this.queue = new ConcurrentQueue<double>();
            this.queue.Enqueue(timeInWindow);
        }

        public bool IsRequestAllowed()
        {
            var currTime = DateTime.UtcNow.TimeOfDay.TotalMilliseconds;

            //Remove expired entries before you allow new entries, make space for new requests.
            RemoveExpiredEntries(currTime);
            if (this.queue.Count < this.queueCapacity)
            {
                this.queue.Enqueue(currTime);

                return true;
            }

            return false;
        }

        public void RemoveExpiredEntries(double currentTime)
        {
            if (this.queue.Count == 0)
            { 
                return; 
            }

            // Since queue is FIFO, Peek() will return the item with oldest timestamp.
            this.queue.TryPeek(out double queueItem);
            var time = (currentTime - queueItem) / 1000;

            while (time <= this.timeInCurrentWindow)
            {
                this.queue.TryDequeue(out _);

                if (this.queue.Count == 0) { break; }

                this.queue.TryPeek(out queueItem);

                // Reset time, to remove all entries less than the allowed time window.
                time = (currentTime - queueItem) / 1000;
            }
        }
    }
}
