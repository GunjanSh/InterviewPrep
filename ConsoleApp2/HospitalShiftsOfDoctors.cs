using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class HospitalShiftsOfDoctors
    {
        public static int GetNumberOfHospitals()
        {
            var arr = new int[2][];
            arr[0] = new int[] { 1, 2, 2 };
            arr[1] = new int[] { 3, 1, 4 };

            var arr2 = new int[3][];
            arr2[0] = new int[] { 1, 1, 5, 2, 3 };
            arr2[1] = new int[] { 4, 5, 6, 4, 3 };
            arr2[2] = new int[] { 9, 4, 4, 1, 5 };

            var dict = new Dictionary<int, HashSet<int>>();

            var rows = arr2.Length;
            var cols = arr2[0].Length;

            for (var i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var doc = arr2[i][j];
                    if (!dict.ContainsKey(doc))
                    {
                        dict[doc] = new HashSet<int>() { i };
                    }
                    else
                    {
                        dict[doc].Add(i);
                    }
                }
            }

            var ans = 0;

            foreach (var item in dict)
            {
                ans += item.Value.Count > 1 ? 1 : 0;
            }

            return ans;
        }
    }
}
