using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Services.ApplicationServices;
using PhoneBook.API.WebAPI.Models;
using PhoneBook.Core.Entites.People;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.API.WebAPI.Controllers
{
    [Route("api/Person")]
    public class PersonController : Controller
    {
        private readonly IPersonService personSevice;

        public PersonController(IPersonService personSevice)
        {
            this.personSevice = personSevice;
        }
        // GET: api/Person
        [HttpGet]
        public List<PersonViewModel> Get()
        {
            var people = personSevice.GetAllPerson();
            List<PersonViewModel> personList = new List<PersonViewModel>();
            foreach (var item in people)
            {
                personList.Add(new PersonViewModel 
                { 
                    PersonId = item.PersonId, 
                    FirstName = item.FirstName, 
                    LastName = item.LastName, 
                    Email = item.Email 
                });
                
            };

            return personList;
        }

        // POST api/Person
        [HttpPost]
        public ActionResult Post([FromBody]Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    personSevice.AddPerson(person);
                    return CreatedAtAction(nameof(Get), new { id = person.PersonId }, person);
                }
            }
        }

        // GET api/Person/{Id}
        [HttpGet("{id:Int}")]
        public ActionResult<Person> Get([FromRoute]int id)
        {
            var resulte = personSevice.GetPerson(id);
            if (resulte == null || resulte?.PersonId < 1)
            {
                return NotFound();
            }
            else
            {
                return Ok(resulte);
            }

        }

        // PUT api/Person/{Id}
        [HttpPut("{id:Int}")]
        public ActionResult Put([FromRoute]int id, [FromBody]Person person)
        {
            if (id < 1)
            {
                return NotFound();
            }
            else
            {
                personSevice.UpdatePerson(id);
                return NoContent();
            }
        }

        // DELETE api/Person/{Id}
        [HttpDelete("{id:Int}")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            else
            {
                personSevice.DeletePerson(id);
                return NoContent();
            }
           
        }
    }
}
