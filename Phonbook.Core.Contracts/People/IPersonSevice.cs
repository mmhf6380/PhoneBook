using PhoneBook.Core.Entites.People;
using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Services.ApplicationServices
{
    public interface IPersonSevice
    {
        List<Person> GetAllPerson();
        Person GetPerson(int personId);
        Person GetPersonWithPhoneList(int personId);
        void AddPerson(Person person);
        void AppPhoneForPerson(int personId, Phone phone);
        void UpdatePerson(int personId);
        void UpdatePhoneForPerson(int phoneId);
        void DeletePerson(int personId);
        void DeletePhoneForPerson(int PhoneId);


    }
}
