using System;
using System.Collections.Generic;
using System.Text;

namespace RadioSample
{
    delegate void OntvangstMethode(string msg);

    class RadioStation
    {
        public const int pi = 3;
        public event OntvangstMethode subscribers;

        public void Broadcast()
        {
            Console.WriteLine("Het radiostation zend nu uit");
            subscribers?.Invoke("Hallo");
        }
    }
}
