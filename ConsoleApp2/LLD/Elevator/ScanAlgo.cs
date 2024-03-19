using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.LLD.Elevator
{
    internal class ScanAlgo
    {             
        internal static int ElevatorAlgo(List<int> requests, int initialFloor)
        {
            int currentFloor = initialFloor;
            int seekTime = 0;

            //requests.Sort();

            // We will move up the elevator first then move down.

            foreach (int request in requests)
            {
                if (request >= currentFloor)
                {
                    seekTime += Math.Abs(request - currentFloor);

                    //set current requested floor to current floor.
                    currentFloor = request;

                    requests.Remove(request);
                }
            }

            // We are done processing requests in upward direction,
            // now process the requests in downward direction.

            foreach (int request in requests)
            {
                seekTime += Math.Abs(request - currentFloor);
                currentFloor = request;

                requests.Remove(request);
            }

            return seekTime;
        }
    }
}
