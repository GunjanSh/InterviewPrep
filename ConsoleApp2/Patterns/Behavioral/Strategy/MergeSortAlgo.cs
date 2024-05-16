using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Strategy
{
    internal class MergeSortAlgo : ISortingAlgo
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sort using Merge Sort algorithm");
        }
    }
}
