using ACME.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    //class Dummy
    //{
    //    public string First { get; set; }
    //    public string Last { get; set; }
    //}

    class Program
    {
        static List<Person> people = new List<Person>();

        //static bool FindBtFirstNameStartingWithA(Person p)
        //{
        //    return p.FirstName.StartsWith("A");
        //}
        //static bool FindBtFirstNameStartingWithB(Person p)
        //{
        //    return p.FirstName.StartsWith("B");
        //}
        static void Main(string[] args)
        {
            PopulateList();

            var query = people
                .Where(p=>p.FirstName.StartsWith("C"))
                .OrderBy(p => p.LastName)
                .Select(p=>new { First = p.FirstName, Last = p.LastName })
                .Take(3);

            var q2 = from p in people 
                     orderby p.Age descending 
                     where p.FirstName.StartsWith("A") 
                     select p;

            foreach (var p in query)
            {
                Console.WriteLine($"{p.First} {p.Last}");
            }

            foreach (Person p in q2.Take(5))
            {
                Console.WriteLine($"[{p.ID}] {p.FirstName} {p.LastName} ({p.Age})");
            }
        }

        static void PopulateList()
        {
            people = new Bogus.Faker<Person>()
                .RuleFor(p => p.ID, fk => fk.IndexFaker)
                .RuleFor(p => p.FirstName, fk=>fk.Name.FirstName())
                .RuleFor(p => p.LastName, fk => fk.Name.LastName())
                .RuleFor(p => p.Age, fk => fk.Random.Int(0, 123))
                .Generate(100).ToList();
        }
    }
}
