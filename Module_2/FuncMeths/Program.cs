using System;
using System.Linq;

namespace FuncMeths
{
    class Program
    {
        static void Main(string[] args)
        {
            int len;
            GeeftLengte(out len);

            int a = 10;
            int b = 20;
            Console.WriteLine($"a={a}, b={b}");
            Swap(ref a,ref  b);
            Console.WriteLine($"a={a}, b={b}");

            var result  = TelOp(c:4L, a:7L);
            ShowNumber(result);
        }

        static void GeeftLengte(out int ln)
        {
            ln = 20;
        }
        static void Swap(ref int aaa,ref  int bbb)
        {
            int tmp = aaa;
            aaa = bbb;
            bbb = tmp;
        }

        // Procedure
        // void DoeIets(int agr1, string arg2){}
        static void ShowNumber(int nr)
        {
            Console.WriteLine($"Het getal is {nr}");
        }
        static void ShowNumber(long nr)
        {
            Console.WriteLine($"Het getal is {nr}");
        }


        // Function
        // Type DoeIetsint arg1, string arg2){}
        static int TelOp(int a, int b)
        {
            return a + b;
        }
        // Overload
        static long TelOp(long a = 1L, long b = 2L, long c = 3L)
        {
            return a + b + c;
        }
        static long TelOp(params int[] nrs)
        {
            return nrs.Sum();
        }


    }
}
