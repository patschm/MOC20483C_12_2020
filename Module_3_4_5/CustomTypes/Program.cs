using System;


namespace Booeeee
{
    // Custom type
    // Geeft duiding aan een getal
    enum Weekdays : int
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
}
namespace CustomTypes
{
    //using Blaat;
    using Booeeee;
    class Program
    {
        static void Main(string[] args)
        {
            int dag = 2;
            Weekdays d2 = (Weekdays)3;
            Console.WriteLine(d2);
        }
    }
}

namespace Blaat
{
    // Custom type
    // Geeft duiding aan een getal
    enum Weekdays : int
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
}
