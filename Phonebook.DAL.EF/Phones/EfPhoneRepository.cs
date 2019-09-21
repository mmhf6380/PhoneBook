using Phonbook.Core.Contracts.Phones;
using Phonebook.DAL.EF.Common;
using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.DAL.EF.Phones
{
    public class EfPhoneRepository : IPhoneRepository
    {
        private readonly PhoneBookContext context;

        public EfPhoneRepository(PhoneBookContext phonbookContext)
        {
            context = phonbookContext;
        }
        public Phone Add(Phone phone)
        {
            context.Phones.Add(phone);
            context.SaveChanges();
            return phone;
        }

        public void Delete(int Id)
        {
            context.Phones.Remove(Get(Id));
            context.SaveChanges();
        }

        public Phone Get(int Id)
        {
            return context.Phones.Find(Id);
        }
    }
}
