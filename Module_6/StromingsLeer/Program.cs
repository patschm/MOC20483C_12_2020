using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace StromingsLeer
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteToStreamForRealMen();
            //ReadFromStreamForRealMen();
            //WriteToStreamLean();
            //ReadFromStreamLean();
            //WriteToStreamCompressed();
            ReadFromStreamCompressed();
        }

        private static void ReadFromStreamCompressed()
        {
            FileStream str = File.OpenRead(@"E:\data2.zip");
            GZipStream zip = new GZipStream(str, CompressionMode.Decompress);
            StreamReader rdr = new StreamReader(zip);
            string line;
            while ((line = rdr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            str.Close();
        }

        private static void WriteToStreamCompressed()
        {
            FileStream str = File.Create(@"E:\data2.zip");
            GZipStream zip = new GZipStream(str, CompressionMode.Compress);
            StreamWriter wrt = new StreamWriter(zip);
            for (int i = 0; i < 1000; i++)
            {
                wrt.WriteLine("Hello World " + i);
            }
            wrt.Flush();
            str.Close();
        }

        private static void ReadFromStreamLean()
        {
            FileStream str = File.OpenRead(@"E:\data2.txt");
            StreamReader rdr = new StreamReader(str);
            string line;
            while((line= rdr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            str.Close();
        }

        private static void WriteToStreamLean()
        {
            FileStream str = File.Create(@"E:\data2.txt");
            StreamWriter wrt = new StreamWriter(str);
            for (int i = 0; i < 1000; i++)
            {
                wrt.WriteLine("Hello World " + i);
            }
            wrt.Flush();
            str.Close();
        }

        private static void ReadFromStreamForRealMen()
        {
            FileStream str = File.OpenRead(@"E:\data.txt");

            byte[] buffer = new byte[512];
            int nrRead = str.Read(buffer, 0, buffer.Length);
            while(nrRead > 0)
            {
                string data = Encoding.UTF8.GetString(buffer);
                Console.Write(data);
                Array.Clear(buffer, 0, buffer.Length);
                nrRead = str.Read(buffer);
            }
            
        }

        private static void WriteToStreamForRealMen()
        {
            FileStream str = File.Create(@"E:\data.txt");
            // FileStream str = new FileStream("", FileMode.Open, FileAccess.Write, FileShare.Read);

            for (int i = 0; i < 1000; i++)
            {
                byte[] buffer = Encoding.UTF8.GetBytes("Hello World " + i +"\n");
                str.Write(buffer);
            }
            str.Close();
        }
    }
}
