using System;

namespace Schrijfblok
{
    class Program
    {
        static void Main(string[] args)
        {
            Pen p = new Pen { Kleur = ConsoleColor.Red, LijnDikte = 10 };

            p.Schrijf("Hello World");
        }
    }
}
