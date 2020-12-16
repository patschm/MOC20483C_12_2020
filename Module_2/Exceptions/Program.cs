using System;
using System.Diagnostics;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("E:\\log.txt"));
            
            try
            {
                //DoeIets();
                BusinessLogic();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Alles? {e.Message}");
                Console.WriteLine(e.StackTrace);

            }
            Trace.Flush();
        }

        static void DoeIets()
        {
            try
            {
                int res = int.Parse("sdfsdff");
            }
            catch(OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                Console.WriteLine(oe.HResult);
                Console.WriteLine(oe.Source);
                Console.WriteLine(oe.StackTrace);
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Fout nummer");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void BusinessLogic()
        {
            try
            {
                int.Parse("2000000000000");
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Opruimen...");
            }
        }
    }
}
