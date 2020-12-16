using System;
using System.IO;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //StatischeDemo();
            InstanceDemo();
        }

        private static void InstanceDemo()
        {
            FileInfo fi = new FileInfo(@"E:\bla.txt");

            if (fi.Exists)
            {
                fi.Delete();
            }
            else
            {
                fi.Create().Close();
            }
        }

        private static void StatischeDemo()
        {
            string file = @"E:\bla.txt";
            if (File.Exists(file))
            {
                Console.WriteLine("Bestaat");
                File.Delete(file);
            }
            else
            {
                File.Create(file).Close();
            }
        }
    }
}
