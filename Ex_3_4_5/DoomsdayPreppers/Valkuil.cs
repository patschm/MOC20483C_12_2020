using IEEE;
using System;

namespace DoomsdayPreppers
{
    public class Valkuil:IDevice
    {
        public void OnDetect()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("De valkuil met scherpe spiezen gaat open");
        }
    }
}
