using ACME.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACME.ConsoleClient
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var phent = modelBuilder.Entity<PersonHobby>();
            phent.HasKey(ph => new { ph.PersonID, ph.HobbyID });
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PersonHobby> PersonHobbies { get; set; }
    }
}

