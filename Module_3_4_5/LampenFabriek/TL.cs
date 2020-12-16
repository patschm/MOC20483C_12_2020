using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LampenFabriek
{
    sealed class TL : Lamp
    {
        public int StarterAantal { get; set; } = 5;

        public sealed override void Aan()
        {
            for (int i = 0; i < StarterAantal; i++)
            {
                Console.ResetColor();
                Console.Clear();
                Console.BackgroundColor = Kleur;
                Console.WriteLine($"De TL brand met {Lumen} Lumen");
                Task.Delay(100).Wait();
            }
        }
        public override void Uit()
        {
            Console.WriteLine("De TL gaat uit");
            Console.ResetColor();
        }

    }
}
