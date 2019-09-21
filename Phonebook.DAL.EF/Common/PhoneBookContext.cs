using Microsoft.EntityFrameworkCore;
using Phonebook.DAL.EF.People;
using Phonebook.DAL.EF.Phones;
using PhoneBook.Core.Entites.People;
using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.DAL.EF.Common
{
    public class PhoneBookContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=PhonBookDb;integrated security =True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PhoneConfig());
        }
    }
}
