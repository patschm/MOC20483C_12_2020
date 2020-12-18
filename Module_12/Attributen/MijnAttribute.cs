using System;
using System.Collections.Generic;
using System.Text;

namespace Attributen
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MijnAttribute : Attribute
    {
        public int Age { get; set; }

        public void Validate()
        {
            if (Age < 67)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Hier bent u te oud voor");
            }
        }
    }
}
