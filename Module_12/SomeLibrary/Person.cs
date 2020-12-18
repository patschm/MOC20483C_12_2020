using System;
using System.Runtime.InteropServices;

namespace SomeLibrary
{
    /// <summary>
    /// Dit stelt een persoon voor
    /// </summary>
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
        /// <summary>
        /// Set hier de naam neer
        /// <code>
        /// </code>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Introduceert
        /// </summary>
        /// <param name="i">Hoe vaak dan?</param>
        public void Introduce(int i = 0)
        {
            Console.WriteLine($"Hallo. Ik ben {Name} and {Age} years old");
        }

    }
}
