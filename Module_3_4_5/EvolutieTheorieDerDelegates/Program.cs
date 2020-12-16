using System;

namespace EvolutieTheorieDerDelegates
{
    delegate int MathDel(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            // Framework 1.0/1.1
            MathDel m1 = new MathDel(Add);
            var result = m1(1, 2);

            // Framework 2.0
            MathDel m2 = Add;
            result = m2(2, 3);

            int c = 10;
            MathDel m3 = delegate (int a, int b)
            {
                return a + b + c;
            };
            result = m3(3, 4);

            // Framework 3.0/3.5
            MathDel m4 = (a, b) => a + b;
            result = m4(5, 6);

            // Functions: Func<int>
            Func<int, int, int> m5 = (a, b) => a + b; 
            result = m5(7, 8);
            // Procedures: Action<>
            Action<int> cw = Console.WriteLine;

            cw(result);
            //Console.WriteLine(result);

            // C# 8
            int LocalAdd(int a, int b)
            {
                return a + b;
            }

            result = LocalAdd(9, 10);
            cw(result);
        }


        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
