using System;
using System.Collections.Generic;
using System.Text;

namespace Schrijfblok
{
    class Pen
    {
        private int lijnDikte;

        public int LijnDikte
        {
            get { return lijnDikte; }
            set
            {
                if (value > 0 && value <= 20)
                {
                    lijnDikte = value;
                }
            }
        }
        public ConsoleColor Kleur { get; set; }
        public string Font { get; set; }

        public void Schrijf(string text)
        {
            Console.ForegroundColor = Kleur;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
