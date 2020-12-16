using System;
using System.Collections.Generic;
using System.Text;

namespace DeFabriek
{
    class Maarten:Person, IContract
    {
        public override void Werken()
        {
            Programmeert();
        }
        public void Programmeert()
        {
            Console.WriteLine("Maarten programmeert");
        }

        public void VoerUit()
        {
            Programmeert();
        }
    }
}
