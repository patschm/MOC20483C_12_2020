using ACME.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Serializers
{
    class Program
    {
        static void Main(string[] args)
        {
            //SerializeDemo();
            //DeserializeDemo();
            //SerializeJsonDemo();
            DeserializeJsonDemo();
        }

        private static void DeserializeJsonDemo()
        {
            FileStream str = File.OpenRead(@"E:\data.json");
            JsonSerializer serializer = new JsonSerializer();
            StreamReader rdr = new StreamReader(str);
            var list = serializer.Deserialize(rdr, typeof(List<Person>)) as List<Person>;
            foreach (var p in list)
            {
                Console.WriteLine(p.FirstName);
            }
        }

        private static void SerializeJsonDemo()
        {
            var people = new Bogus.Faker<Person>()
               .RuleFor(p => p.ID, fk => fk.IndexFaker)
               .RuleFor(p => p.FirstName, fk => fk.Name.FirstName())
               .RuleFor(p => p.LastName, fk => fk.Name.LastName())
               .RuleFor(p => p.Age, fk => fk.Random.Int(0, 123))
               .Generate(100).ToList();

            FileStream str = File.Create(@"E:\data.json");
            JsonSerializer serializer = new JsonSerializer();
            StreamWriter wrt = new StreamWriter(str);
            serializer.Serialize(wrt, people);
            wrt.Close();

        }

        private static void DeserializeDemo()
        {
            FileStream str = File.OpenRead(@"E:\data.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            var list = serializer.Deserialize(str) as List<Person>;
            foreach(var p in list)
            {
                Console.WriteLine(p.FirstName);
            }
        }

        private static void SerializeDemo()
        {
           var people = new Bogus.Faker<Person>()
               .RuleFor(p => p.ID, fk => fk.IndexFaker)
               .RuleFor(p => p.FirstName, fk => fk.Name.FirstName())
               .RuleFor(p => p.LastName, fk => fk.Name.LastName())
               .RuleFor(p => p.Age, fk => fk.Random.Int(0, 123))
               .Generate(100).ToList();

            FileStream str = File.Create(@"E:\data.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            serializer.Serialize(str, people);
            str.Close();
        }
    }
}
