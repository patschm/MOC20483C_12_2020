using System;
using System.Security.Cryptography;
using System.Text;

namespace Integrity
{
    class Program
    {
        static void Main(string[] args)
        {
            //HashBasic();
            //SymmetricDemo();
            AsymmetrischeDemo();
        }

        private static void AsymmetrischeDemo()
        {
            // Sender
            string msg = "Hello World";
            DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
            string pubKey = dsa.ToXmlString(false);
            byte[] hash = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(msg));
            byte[] signature = dsa.SignHash(hash , "SHA1");

            msg += ".";

            // Receiver
            DSACryptoServiceProvider rec = new DSACryptoServiceProvider();
            rec.FromXmlString(pubKey);
            byte[] rechash = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(msg));
            bool isOk = rec.VerifyHash(rechash, "SHA1", signature);
            Console.WriteLine(isOk ? "Goed": "Fout");
        }

        private static void HashBasic()
        {
            string msg = "Hello World";

            var alg = SHA256.Create();
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            byte[] hash = alg.ComputeHash(buffer);
            Console.WriteLine(Convert.ToBase64String(hash));
        }

        private static void SymmetricDemo()
        {
            // Sender
            string msg = "Hello World";

            HMACSHA1 hmac = new HMACSHA1();
            byte[] key = hmac.Key;
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(msg));

            //msg += ".";

            // Receiver
            HMACSHA1 rec = new HMACSHA1();
            rec.Key = key;
            byte[] rechash = rec.ComputeHash(Encoding.UTF8.GetBytes(msg));
            Console.WriteLine(Convert.ToBase64String(rechash));
            Console.WriteLine(Convert.ToBase64String(hash));
        }
    }
}
