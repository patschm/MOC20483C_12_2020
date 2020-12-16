using System;
using System.Collections.Generic;
using System.Text;

namespace Weird
{
    class Etage
    {
        // Instance member. Behoort tot het concrete object
        public int EtageNummer { get; set; }
        // Class member. Behoort tot alle objecten van dit type
        public static Lift elevator = new Lift();

        public void CallLift()
        {
            elevator.Call(EtageNummer);
        }
        public void ShowLiftStatus()
        {
            Console.WriteLine($"{Etage.elevator.CurrentFloor}");
        }
    }
}
