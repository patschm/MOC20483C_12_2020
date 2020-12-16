using System;
using System.Collections.Generic;
using System.Text;

namespace LampenFabriek
{
    abstract class Lamp
    {
        // Field. Hierin slaan wij de eigenschappen op.
        //private ConsoleColor kleur = ConsoleColor.Green;
        private int lumen = 100;

        // Een Property die een field beschermd tegen onzin waardes
        // Encapsulation
        public int Lumen
        {
            get
            {
                return lumen;
            }
            set
            {
                if (value >= 0 && value < 1000)
                {
                    lumen = value;
                }
            }
        }
        // Auto generating property. Genereert zijn eigen private field
        public ConsoleColor Kleur { get; set; } = ConsoleColor.Green;

        // Methods. Hierin leggen we gedrag vast
        public virtual void Aan()
        {
            Console.BackgroundColor = Kleur;
            Console.WriteLine($"De lamp brand met {Lumen} Lumen");
        }
        public abstract void Uit();
        //{
        //    Console.WriteLine("De lamp gaat uit");
        //    Console.ResetColor();
        //}

        // Contructors
        // Gebruik je alleen om de fields van een initiele waarde te voorzien
        // Zo weinig mogelijk gebruiken
        public Lamp()
        {
            Lumen = 100;
            Kleur = ConsoleColor.Green;
        }
        public Lamp(int lumen, ConsoleColor kleur)
        {
            this.Lumen = lumen;
            this.Kleur = kleur;
        }
    }
}
