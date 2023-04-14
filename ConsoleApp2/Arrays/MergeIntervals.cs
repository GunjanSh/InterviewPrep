using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Arrays
{
    public class Interval
    {
        public int Start;
        public int End;
    }

    internal class MergeIntervals
    {
        public static void Solve()
        {
            //List<List<int>> list = new List<List<int>>()
            //{
            //    new List<int> {1, 2},
            //    new List<int> {3, 6},
            //};

            //int start = 10;
            //int end = 8;

            List<List<int>> list = new List<List<int>>()
            {
                new List<int> {1, 3},
                new List<int> {6, 9},
            };

            int start = 2;
            int end = 5;

            Merge(list, start, end);
        }

        static List<List<int>> Merge(List<List<int>> intervals, int startNew, int endNew)
        {
            List<Interval> list = new List<Interval>();
            List<List<int>> output = new List<List<int>>();

            //foreach (var item in intervals)
            //{
            //    list.Add(new Interval { Start = item[0], End = item[1] });
            //}

            //var startInterval = list[0].Start;
            //var endInterval = list[0].End;

            //for(int idx = 1; idx < list.Count; idx++)
            //{
            //    if (list[idx].Start > startNew && )
            //}


            //while (count <= list.Count - 1)
            //{
            //    int start, end;

            //    if (list[count].Start < startNew)
            //    {
            //        start = list[count].Start;
            //    }
            //    else
            //    {
            //        start = startNew;
            //    }

            //    if (list[count].End < endNew)
            //    {
            //        end = endNew;
            //    }
            //    else
            //    {
            //        end = list[count].End;
            //    }

            //    count++;
            //    output.Add(new List<int> { start, end });
            //}

            return output;
        }
    }
}
