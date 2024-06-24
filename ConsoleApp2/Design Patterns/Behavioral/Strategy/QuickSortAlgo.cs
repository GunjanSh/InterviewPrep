using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Strategy
{
    internal class QuickSortAlgo : ISortingAlgo
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sort using Quick Sort algorithm");
        }
    }
}
