using System;

namespace Weird
{
    struct Complex
    {
        public int Real { get; set; }
        public int Imaginair { get; set; }

        public static Complex operator+(Complex a, Complex b)
        {
            return new Complex { 
                Real = a.Real + b.Real, 
                Imaginair = a.Imaginair + b.Imaginair 
            };
        }

        public override string ToString()
        {
            return $"({Real} + {Imaginair}i)".SponsoredBy("Patrick");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello World";

            Console.WriteLine(StringUtils.SponsoredBy(s, "Sony"));
            Console.WriteLine(s.SponsoredBy("Sony"));
            //Etage[] flat = new Etage[50];
            //for(int i = 0; i < flat.Length; i++)
            //{
            //    flat[i] = new Etage { EtageNummer = i };
            //}

            //flat[45].CallLift();

            //foreach(Etage et in flat)
            //{
            //    et.ShowLiftStatus();
            //}

            Complex c1 = new Complex { Real = 10, Imaginair = 20 };
            Complex c2 = new Complex { Real = 20, Imaginair = 30 };

            Complex c3 =c1 + c2;
            Console.WriteLine(c3);

            //Console.WriteLine(c1);
            //DoeIets(c1);
            //Console.WriteLine(c1);
        }

        static void DoeIets(Complex ccc)
        {
            ccc.Real = 100;
            ccc.Imaginair = 200;
        }
    }
}
