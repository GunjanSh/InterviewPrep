using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class File : IComparable<File>
    {
        public string Name { get; set; }

        public long Size { get; set; }

        public string Directory { get; set; }

        //Won't work as we need priority queue with both size and dir
        public int CompareTo(File? other)
        {
            if (other == null)
                return 1;

            return other.Size.CompareTo(Size);
        }
    }
}
