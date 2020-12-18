using SomeLibrary;
using System;

namespace Attributen
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            SomeClass c1 = new SomeClass();
            FancyRuntime(c1);
        }

        private static void FancyRuntime(SomeClass c1)
        {
            var arrts = c1.GetType().GetCustomAttributes(typeof(MijnAttribute), false);
            MijnAttribute ma = arrts[0] as MijnAttribute;

            if (ma.Age < 67)
            {
                c1.DoeIets();
            }
            else
            {
                Console.WriteLine("Hier bent u te oud voor");
            }
        }
    }


}
