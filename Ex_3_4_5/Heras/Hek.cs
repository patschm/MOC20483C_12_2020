using IEEE;
using System;

namespace Heras
{
    public class Hek:IDevice
    {
        public void OnDetect()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("Hek gaat open");
        }
    }
}
