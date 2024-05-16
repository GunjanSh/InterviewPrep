using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Strategy
{
    /*
     * Strategy is a behavioral design pattern that lets you define a family of algorithms, 
     * put each of them into a separate class, and make their objects interchangeable.
     * 
     * 
     */

    internal class Strategy
    {
        ISortingAlgo sortingAlgo;

        public Strategy(ISortingAlgo sortingAlgo)
        {
            this.sortingAlgo = sortingAlgo;
        }

        public void SortData(List<int> data)
        {
            this.sortingAlgo.Sort(data);
        }
    }
}
