using System;

namespace WK
{
    class Program
    {
        static void Main(string[] args)
        {
            SimonvdMeer svdm = new SimonvdMeer();
            WillemKlein wk = new WillemKlein();

            //wk.Calculate(svdm.Subtract, 8, 4);

            MathDel m1 = svdm.Add;
            m1 += svdm.Add;
            m1 += svdm.Subtract;
            m1 -= svdm.Subtract;
            m1 += svdm.Subtract;

            foreach(var mi in m1.GetInvocationList())
            {
                Console.WriteLine(mi.Method.Name);
            }


            var res = m1(1, 2);

            Console.WriteLine(res);


            
        }
    }
}
