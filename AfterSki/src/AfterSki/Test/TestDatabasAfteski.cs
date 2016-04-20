using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;


namespace AfterSki.Test
{
    public class TestDatabasAfteski : DbContext
    {
            public TestDatabasAfteski(DbContextOptions options)
                : base(options)
            {
            }

            public DbSet<Person> People { get; set; }
        }

        public class Person
        {
            [Key]
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    
}
