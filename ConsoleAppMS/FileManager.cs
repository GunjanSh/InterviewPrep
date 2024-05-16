using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /*
     *  [t1.exe, size: 100]
[t2.txt, size: 200, "dir1"]
[t3.jpg, size: 200, "dir1"]
[t4.xls, size: 300, "dir2"]
[t5.doc, size: 100]

    dir1: 400

     */

    public class LongMaxComparer : IComparer<(long size, string dir)>
    {
        public int Compare((long size, string dir) x, (long size, string dir) y)
        {
            return y.size.CompareTo(x.size);
        }
    }

    public class FileComparator : IComparer<(long size, string dir)>
    {
        public int Compare((long size, string dir) x, (long size, string dir) y)
        {
            if (x.size == y.size)
                return 0;
            else if (x.size < y.size)
                return 1;
            else
                return -1;
        }
    }

    internal class FileManager
    {
        List<File> Files;           // Use a variable to store Total sum
        Dictionary<string, long> FileSizes;
        PriorityQueue<(long, string), (long, string)> Pq;
        long TotalSum = 0;

        public FileManager()
        {
            this.Files = new List<File>();
            this.FileSizes = new Dictionary<string, long>();
            //this.Pq = new PriorityQueue<(long, string), (long, string)>(new FileComparator());
            this.Pq = new PriorityQueue<(long, string), (long, string)>(new LongMaxComparer());
            //this.Pq = new PriorityQueue<(long, string), (long, string)>();
        }

        public void ProcessData(List<File> data)
        {
            //this.Files.AddRange(data);

            //O(n)
            foreach (var file in data)
            {
                this.TotalSum += file.Size;

                if (file.Directory != null)
                {

                    if (!FileSizes.ContainsKey(file.Directory))
                    {
                        FileSizes[file.Directory] = file.Size;
                    }
                    else
                    {
                        FileSizes[file.Directory] += file.Size;
                    }
                }
            }
            
            //O(log n) +  number of directories      // should be *
            foreach (var file in FileSizes)
            {
                Pq.Enqueue((file.Value, file.Key), (file.Value, file.Key));
            }
        }

        public long GetTotalFileSize()
        {
            return this.TotalSum;
        }

        public List<long> GetTopFileDetails(int top)
        {
            List<long> list = new List<long>();

            //O( log n) * top
            for(int i = 0; i < top; i++)
            {
                list.Add(Pq.Dequeue().Item1);
            }

            return list;
        }
    }
}
