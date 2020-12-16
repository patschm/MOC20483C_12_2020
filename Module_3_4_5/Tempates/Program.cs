using System;
using System.Collections;
using System.Collections.Generic;

namespace Tempates
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList list = new ArrayList();
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            foreach(int nr in list)
            {
                Console.WriteLine(nr);
            }


            int a = 10;
            int b = 20;
            Console.WriteLine($"a: {a}, b: {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"a: {a}, b: {b}");
        }

        static void Swap<T>(ref T a, ref T b) where T: IFormattable
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
        //static void Swap(ref double a, ref double b)
        //{
        //    double tmp = a;
        //    a = b;
        //    b = tmp;
        //}
        //static void Swap(ref long a, ref long b)
        //{
        //    long tmp = a;
        //    a = b;
        //    b = tmp;
        //}
        //static void Swap(ref int a, ref int b)
        //{
        //    int tmp = a;
        //    a = b;
        //    b = tmp;
        //}
        //static void Swap(ref float a, ref float b)
        //{
        //    float tmp = a;
        //    a = b;
        //    b = tmp;
        //}
    }
}
