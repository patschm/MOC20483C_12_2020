using System;
using System.Collections.Generic;
using System.Text;

namespace DeFabriek
{
    class Bokito : IContract
    {
        public void MeptDamesInElkaar()
        {
            Console.WriteLine("Bokito mept er op los");
        }

        public void VoerUit()
        {
            MeptDamesInElkaar();
        }
    }
}
