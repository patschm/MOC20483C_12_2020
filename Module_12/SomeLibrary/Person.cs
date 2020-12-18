using System;
using System.Runtime.InteropServices;

namespace SomeLibrary
{
    [Obsolete("Person is obsolete. Use Persoon instead", false)]
    public class Person
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value < 123)
                {
                    age = value;
                }
            }
        }
        public string Name { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"Hallo. Ik ben {Name} and {Age} years old");
        }

    }
}
