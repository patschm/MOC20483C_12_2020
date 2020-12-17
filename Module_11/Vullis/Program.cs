using System;

namespace Vullis
{
    class Program
    {
        public static URes res1 = new URes();
        public static URes res2 = new URes();

        static void Main(string[] args)
        {
            try
            {
                res1.Open();
            }
            finally
            {
                res1.Dispose();
            }

            using (res2)
            {
                res2.Open();
            }
            
            using (URes res3 = new URes())
            {
                res3.Open();
            }

            //GC.Collect();
            //GC.WaitForPendingFinalizers();
           
            Console.ReadLine();
        }
    }
}
