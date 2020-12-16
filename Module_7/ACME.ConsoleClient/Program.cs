using ACME.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ACME.ConsoleClient
{
    class Program
    {
        static string conStr = @"Server=.\sqlexpress;Database=MensenDB;Trusted_Connection=True;MultipleActiveResultSets=true;";

        static void Main(string[] args)
        {
            //FillTable();
            DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
            bld.UseSqlServer(conStr);

            PeopleContext ctx = new PeopleContext(bld.Options);
            var query = ctx.People
                .Include(p => p.Hobbies)
                    .ThenInclude(ph => ph.Hobby);

            foreach(Person p in query)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName}");
                //ctx.Entry(p).Collection(px => px.Hobbies).Load();
                foreach(var ph in p.Hobbies)
                {
                    //ctx.Entry(ph).Reference(pph => pph.Hobby).Load();
                    Console.WriteLine($"\t{ph.Hobby.Description}");
                }
            }



            // ctx.Database.EnsureCreated();

            //Person p1 = new Person { FirstName = "Karel", LastName = "Doorman", Age = 150 };
            //Hobby h1 = new Hobby { Description = "Zeilen" };
            //PersonHobby ph = new PersonHobby { Hobby = h1, Person = p1 };
            //p1.Hobbies.Add(ph);

            //ctx.People.Add(p1);

            //var p1 = ctx.People.First();
            //p1.FirstName = "Petra";

            //ctx.People.Remove(p1);

            //ctx.SaveChanges();

            System.Console.WriteLine("Klaar");
        }

        private static void FillTable()
        {
            DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
            bld.UseSqlServer(conStr);
            PeopleContext ctx = new PeopleContext(bld.Options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var hobbies = new Bogus.Faker<Hobby>()
                .RuleFor(h => h.Description, fk => fk.Company.CatchPhrase())
                .Generate(1000).ToArray();

            var people = new Bogus.Faker<Person>()
                .RuleFor(p => p.FirstName, fk => fk.Name.FirstName())
                .RuleFor(p => p.LastName, fk => fk.Name.LastName())
                .RuleFor(p => p.Age, fk => fk.Random.Int(0, 123))
                .Generate(100).ToArray();

            var ph = new Bogus.Faker<PersonHobby>()
                .RuleFor(ph => ph.Hobby, fk => fk.Random.ArrayElement(hobbies))
                .RuleFor(ph => ph.Person, fk => fk.Random.ArrayElement(people))
                .Generate(100).ToList();

            foreach(var p in ph)
            {
                ctx.PersonHobbies.Add(p);
            }
            ctx.SaveChanges();

        }
    }
}
