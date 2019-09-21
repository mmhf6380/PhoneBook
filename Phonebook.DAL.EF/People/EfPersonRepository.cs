using Microsoft.EntityFrameworkCore;
using Phonbook.Core.Contracts.People;
using Phonebook.DAL.EF.Common;
using PhoneBook.Core.Entites.People;
using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.DAL.EF.People
{
    public class EfPersonRepository : IPersonRepository
    {
        private readonly PhoneBookContext context;

        public EfPersonRepository(PhoneBookContext phonbookContext)
        {
            context = phonbookContext;
        }
        public Person Add(Person person)
        {
            context.People.Add(person);
            context.SaveChanges();
            return person;
        }

        public void Delete(int Id)
        {
            context.People.Remove(Get(Id));
            context.SaveChanges();
        }

        public Person Get(int Id)
        {
            return context.People.Find(Id);
        }

        public List<Person> GetAll()
        {
            return context.People.ToList();
        }

        public void Savechange()
        {
            context.SaveChanges();
        }
    }
}
