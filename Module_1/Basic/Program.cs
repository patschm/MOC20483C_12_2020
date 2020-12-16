using System;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Typenaam varnaam;
            // age: variabele
            // 42: literal
            int age = 42000000;
            string name = "hoi";

            // Expressions:   Een of meerdere operands (variabele of literal) waar een operator op werkt
            int a = age + 3;

            int b1 = 1; // 0001
            int b2 = 3; // 0011

            bool bb1 = true;
            bool bb2 = false;

            long l1 = age;  // Implicit cast
           // checked
            {
                short s1 = (short)age;

                Console.WriteLine(s1);
            }

            int? c = null;

            int r1 = c ?? 42;
            

            
        }
    }
}
