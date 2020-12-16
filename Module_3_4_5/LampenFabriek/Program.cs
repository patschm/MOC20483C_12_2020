using System;

namespace LampenFabriek
{
    class Program
    {
        static void Main(string[] args)
        {

            Lamp l1 = new TL
            {
                Kleur = ConsoleColor.Yellow,
                Lumen = -200,
                StarterAantal = 7
            };

            l1.Aan();
            Console.WriteLine("Hoi");
            l1.Uit();
            Console.WriteLine("Doei");

            //Lamp l2 = new Lamp { Kleur = ConsoleColor.Red, Lumen = 100 };
            //l2.Aan();
            //l2.Uit();

            //Lamp l3 = new Lamp();
            //l3.Aan();

            //Lamp l4 = new Lamp(300, ConsoleColor.Magenta);
            //l4.Aan();
        }
    }

   
}
