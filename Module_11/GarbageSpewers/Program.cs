using System;
using System.Diagnostics;
using System.Text;

namespace GarbageSpewers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            //string s = "";
            StringBuilder bld = new StringBuilder();
            watch.Start();
            for (int i = 0; i < 100000; i++)
            {
                bld.Append(i);
                //s += i.ToString();
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
    }
}
