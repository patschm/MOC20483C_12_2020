using System;

namespace Flows
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vooruit springen
            int a = 10;

            // Gebruik voor range checks
            if (a > 10)
            {

            }
            else if (a < 5)
            {

            }
            else
            {

            }

            // Concrete waarde checks
            switch (a)
            {
                case 3:
                case 4:
                    Console.WriteLine("Vier");
                    break;
                case 5:
                    Console.WriteLine("Vijf");
                    break;
                default:
                    Console.WriteLine("Anders");
                    break;
            }

            // Terug springen (loop)
            int idx = 0;
            // for loop als je weet hoe vaak je iets moet herhalen
            for (;idx < 20;)
            {
                idx = idx + 1;
                if (idx == 10)
                    break;
                Console.WriteLine("Hallo " + idx);
                
            }
            Console.WriteLine(idx);

            int b = 0;
            // Als je niet precies weet hoe vaak iets herhaald moet worden
            // 0 of meer keer aangeroepen (Met name in data uitlezen)
            while(b < 10)
            {
                Console.WriteLine(b++);    
            }

            // 1 of meer keer aangeroepen (Met name in UI)
            do
            {
                Console.WriteLine(b++);
            }
            while (b < 20);


        }
    }
}
