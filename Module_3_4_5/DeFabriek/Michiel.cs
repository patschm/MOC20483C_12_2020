using System;
using System.Collections.Generic;
using System.Text;

namespace DeFabriek
{
    class Michiel : Person, IContract
    {
        public override void Werken()
        {
            Verkoopt();
        }
        public void Verkoopt()
        {
            Console.WriteLine("Michiel verkoopt vanalles en nog wat");
        }

        public void VoerUit()
        {
            Verkoopt();
        }
    }
}
