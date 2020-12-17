using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vullis
{
    class URes : IDisposable
    {
        private static bool isOpen = false;
        private FileStream fstr;

        public void Open()
        {
            if (!isOpen)
            {
                Console.WriteLine("Openen...");
                isOpen = true;
                fstr = new FileStream("E:\\blaat.txt", FileMode.OpenOrCreate);
            }
            else
            {
                Console.WriteLine("Pech gehad");
            }
        }
        public void Close()
        {
            Console.WriteLine("Closing....");
            isOpen = false;
           
        }
        private void Dispose(bool fromDispose)
        {
            Close();
            if (fromDispose)
            {
                fstr.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
            
        }

        ~URes()
        {
            Dispose(false);
        }
    }
}
