using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Stacks
{
    internal class SimplifyDirectoryPath
    {
        public static void Solve()
        {
            string path = "/../"; //Ans: "/"
            string simplifiedPath = SimplifyDirPath(path);

            Console.WriteLine("Simplified path for {0} is {1}", path, simplifiedPath);

            path = "/a/./b/../../c/"; //Ans: "/c"
            simplifiedPath = SimplifyDirPath(path);

            Console.WriteLine("Simplified path for {0} is {1}", path, simplifiedPath);

            path = "/home//foo/"; //Ans: "/home/foo/"
            simplifiedPath = SimplifyDirPath(path);

            Console.WriteLine("Simplified path for {0} is {1}", path, simplifiedPath);
        }

        static string SimplifyDirPath(string str)
        {

            string[] dirs = str.Split("/", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();

            foreach (var dir in dirs)
            {
                if (dir == "..")
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }
                else if (dir != ".")
                {
                    stack.Push(dir);
                }
            }

            string[] array = stack.ToArray();
            Array.Reverse(array);

            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("/");

            foreach (var str1 in array)
            {
                strBuilder.Append(str1);
                strBuilder.Append("/");
            }

            return strBuilder.Length > 1 ? strBuilder.Remove(strBuilder.Length-1, 1).ToString() : strBuilder.ToString();
        }
    }
}
