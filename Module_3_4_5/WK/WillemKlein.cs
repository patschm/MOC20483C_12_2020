using System;

namespace WK
{
    delegate int MathDel(int bla, int bliep);

    
    class WillemKlein
    {
        public void Calculate(MathDel bliep, int a, int b)
        {
            Console.WriteLine("Willem gaat rekenen...");

            var result = bliep.Invoke(a, b);

            Console.WriteLine(result);
        }
    }
}