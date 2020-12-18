using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Confidentiality
{
    class Program
    {
        static void Main(string[] args)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine, OpenFlags.ReadOnly);
            var all = store.Certificates.Find(X509FindType.FindBySubjectName, "localhost", false);
            foreach(var cert in all)
            {
                Console.WriteLine(cert.Subject);
                var rsa = cert.PublicKey.Key as RSA;
                Console.WriteLine(rsa);
            }

            //AsymmetrischeDemo();
            //SymmetrischeDemo();
        }

        private static void SymmetrischeDemo()
        {
            // Sender
            string msg = "Hello World";
            TripleDES tdes = new TripleDESCryptoServiceProvider();
            tdes.Mode = CipherMode.CBC;
            byte[] key = tdes.Key;
            byte[] iv = tdes.IV;

            byte[] cipher;
            using (MemoryStream pot = new MemoryStream())
            {
                using (CryptoStream crypt = new CryptoStream(pot, tdes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(crypt))
                    {
                        writer.WriteLine(msg);
                    }
                }
                cipher = pot.ToArray();
            }

            Console.WriteLine(Encoding.UTF8.GetString(cipher));


            // Receiver
            TripleDES rectd = TripleDES.Create();
            rectd.Mode = CipherMode.CBC;
            rectd.Key = key;
            rectd.IV = iv;
            using(MemoryStream mem = new MemoryStream(cipher))
            {
                using(CryptoStream cryp = new CryptoStream(mem, rectd.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cryp))
                    {
                        string data = reader.ReadToEnd();
                        Console.WriteLine(data);
                    }
                }
            }
        }

        private static void AsymmetrischeDemo()
        {
            // De ontvanger koopt een pub/priv certificate
            RSACryptoServiceProvider ontvanger = new RSACryptoServiceProvider();
            string pubKey = ontvanger.ToXmlString(false);

            // De sender
            string msg = "Hello World";
            RSACryptoServiceProvider sender = new RSACryptoServiceProvider();
            sender.FromXmlString(pubKey);
            byte[] cipher = sender.Encrypt(Encoding.UTF8.GetBytes(msg), false);


            // De ontvanger 
            byte[] data = ontvanger.Decrypt(cipher, false);
            Console.WriteLine(Encoding.UTF8.GetString(data));

        }
    }
}
