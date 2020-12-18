using System;
using System.Collections.Generic;
using System.Text;

namespace Attributen
{
    [Mijn(Age = 74)]
    class SomeClass
    {
        public void DoeIets()
        {
            Console.WriteLine("We doen iets");
        }
    }
}
