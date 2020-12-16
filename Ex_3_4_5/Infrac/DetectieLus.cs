using IEEE;
using System;
using System.Collections.Generic;

namespace Infrac
{
    public delegate void DetectDel();

    public class DetectieLus
    {
        private List<IDevice> devices = new List<IDevice>();
        public event DetectDel Detecting;

        public void Connect(IDevice device)
        {
            devices.Add(device);
        }

        public void Detect()
        {
            Console.WriteLine("De detectielus ziet iets");
            //foreach(IDevice device in devices)
            //{
            //    device.OnDetect();
            //}
            Detecting?.Invoke();
        }
    }
}
