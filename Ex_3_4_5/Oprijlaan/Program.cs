using DoomsdayPreppers;
using Heras;
using Infrac;
using Philips;

namespace Oprijlaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Hek hek = new Hek();
            Lamp lamp = new Lamp();
            Valkuil kuil = new Valkuil();
            DetectieLus lus = new DetectieLus();

            lus.Detecting += hek.Open;
            lus.Detecting += kuil.Open;
            lus.Detecting += lamp.Aan;
            //lus.Connect(hek);
            //lus.Connect(kuil);
            //lus.Connect(lamp);


            lus.Detect();
            //hek.Open() Telt Niet!!!!
        }
    }
}
