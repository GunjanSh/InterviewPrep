namespace ConsoleApp
{
    /*
Design a file manager library to process stream of inputs with a list of [FileName, FileSize, [Collection]] - Collection is optional,
Develop a system to provide following outputs:
Calculate total size of files processed.
Calculate Top K collections based on size.
 
Sample Input:
[t1.exe, size: 100]
[t2.txt, size: 200, "dir1"]
[t3.jpg, size: 200, "dir1"]
[t4.xls, size: 300, "dir2"]
[t5.doc, size: 100]

[string, long, List<string>] 


    output:
Total file size processed: 900
Top k=2 collections:
- dir1: 400
- dir2: 300

    top dirs based on size

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<File> files = new List<File>
            {
                new File { Name =  "t1.exe", Size = 100, Directory = null },
                new File {Name = "t2.txt", Size = 200, Directory ="dir1" },
                new File {Name = "t3.jpg",Size = 200, Directory = "dir1" },
                new File {Name = "t4.xls",Size = 300, Directory ="dir2" },
                new File {Name =  "t5.doc", Size = 100, Directory =null },
                new File {Name = "t6.xls",Size = 200, Directory ="dir3" },
                new File {Name = "t4.xls",Size = 300, Directory ="dir4" },
            };

            FileManager mgr = new FileManager();
            mgr.ProcessData(files);

            mgr.GetTopFileDetails(3);

            TopKElements.FindTopKElements();

            Console.WriteLine("Hello, World!");
        }
    }
}
