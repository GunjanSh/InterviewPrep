using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class RotatedSortedArraySearch
    {
        public static int Solve()
        {
            //var list = new List<int> { 1, 7, 67, 133, 178 };
            //var key = 1;

            var list = new List<int> { 101, 103, 106, 109, 158, 164, 182, 187, 202, 205,    2, 3, 32, 57, 69, 74, 81, 99, 100 };
            var key = 202;
            //IReadOnlyList<int> tt = list.AsReadOnly();
            //tt.Count
            Hashtable ht = new Hashtable();
            HashSet<int> hs = new HashSet<int>();

            return Search(list, key);
        }
        public static int Search(List<int> list, int key)
        {
            var low = 0;
            var high = list.Count - 1;

            while (low <= high)
            {
                var mid = low + ((high - low) / 2);

                var midElem = list.ElementAt(mid);
                if (midElem == key)
                {
                    return mid;
                }

                var lowElem = list.ElementAt(low);
                var highElem = list.ElementAt(high);

                if (lowElem <= midElem) // Left sub array is sorted
                {
                    if (key > midElem || key < lowElem) // Check if key is out of bounds wrt sub array index values
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                    //if (key > lowElem || key < midElem)
                    //{
                    //    high = mid - 1;
                    //}
                    //else
                    //{
                    //    low = mid + 1;
                    //}
                }
                else
                {
                    if (key < midElem || key > highElem)  // Check if key is out of bounds wrt sub array index values
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                    //if (key > midElem || key < highElem)
                    //{
                    //    low = mid + 1;
                    //}
                    //else
                    //{
                    //    high = mid - 1;
                    //}
                }
            }

            return -1;
        }
    }
}
