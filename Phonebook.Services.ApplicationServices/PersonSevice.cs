using Phonbook.Core.Contracts.People;
using Phonbook.Core.Contracts.Phones;
using PhoneBook.Core.Entites.People;
using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.Services.ApplicationServices
{
    public class PersonSevice : IPersonService
    {
        private readonly IPersonRepository personRepo;
        private readonly IPhoneRepository phoneRepo;

        public PersonSevice(IPersonRepository personRepository,IPhoneRepository phoneRepository)
        {
            personRepo = personRepository;
            phoneRepo = phoneRepository;
        }

        public void AddPerson(Person person)
        {
            personRepo.Add(person);
        }

        public void AddPhoneForPerson(int personId, Phone phone)
        {
            var person = personRepo.Get(personId);
            person.phones.Add(phone);
            personRepo.Savechange();
            
        }

        public void DeletePerson(int personId)
        {
            var person = personRepo.GetPersonWithPhoneList(personId);

            if (!person.phones.Any())
            {
                personRepo.Delete(personId);
            }
        }


        public void DeletePhoneForPerson(int PhoneId)
        {
            phoneRepo.Delete(PhoneId);
        }

        public List<Person> GetAllPerson()
        {
            return personRepo.GetAll();
        }

        public Person GetPerson(int personId)
        {
            return personRepo.Get(personId);
        }

        public Person GetPersonWithPhoneList(int personId)
        {
            return personRepo.GetPersonWithPhoneList(personId);
        }

        public void UpdatePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhoneForPerson(int phoneId)
        {
            throw new NotImplementedException();
        }
    }
}
