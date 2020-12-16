using System;

namespace DeFabriek
{
    class Program
    {
        static void Main(string[] args)
        {
            // Big Bang
            Bokito bok = new Bokito();
            Michiel mm = new Michiel();
            Maarten m = new Maarten();
            ACME acme = new ACME();
            acme.Hire(m);
            acme.Hire(mm);
            acme.Hire(bok);

            acme.StoomFluit();


            // Big Crunch
        }
    }
}
