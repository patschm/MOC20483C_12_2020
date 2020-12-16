using System;

namespace RadioSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Winnetou wt = new Winnetou();
            RadioStation r538 = new RadioStation();
            r538.subscribers += ViaSms;
            r538.subscribers += ViaSms;
            r538.subscribers += ViaSms;
            r538.subscribers += wt.ViaRooksignalen;
            r538.subscribers += ViaSms;
            r538.subscribers += ViaAether;
            r538.subscribers += ViaPostduif;
            r538.subscribers += ViaSms;
            r538.subscribers += ViaPostduif;
            r538.subscribers += ViaAether;

            r538.Broadcast();

            //r538.subscribers("Hey klojo's!!");

        }

        static void ViaSms(string msg)
        {
            Console.WriteLine($"Via SMS ontvangen: {msg}");
        }
        static void ViaAether(string msg)
        {
            Console.WriteLine($"Via Aether ontvangen: {msg}");
        }
        static void ViaPostduif(string msg)
        {
            Console.WriteLine($"Via postduif ontvangen: {msg}");
        }
    }
}
