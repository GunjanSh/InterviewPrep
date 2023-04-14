using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public static class TowerOfHanoiCalc
    {
        /// <summary>
        /// Towers the of hanoi.
        /// Disk number starts from 1 to number, Start, Stop tower
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static List<List<int>> TowerOfHanoi(int number)
        {
            var output = new List<List<int>>();
            ToH(number, 1, 2, 3, output);

            return output;
        }

        public static void ToH(int diskNumber, int sourceTower, int tempTower, int destinationTower, List<List<int>> list)
        {
            if (diskNumber == 0)
            {
                return;
            }

            ToH(diskNumber - 1, sourceTower, destinationTower, tempTower, list);
            Console.WriteLine("disk: {0}, From: {1} To: {2}", diskNumber, sourceTower, destinationTower);
            list.Add(new List<int> { diskNumber, sourceTower, destinationTower });
            ToH(diskNumber - 1, tempTower, sourceTower, destinationTower, list);
        }
    }
}
