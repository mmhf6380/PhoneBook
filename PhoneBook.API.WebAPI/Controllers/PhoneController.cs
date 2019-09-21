using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Services.ApplicationServices;
using PhoneBook.Core.Entites.People;
using PhoneBook.Core.Entites.Phones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.API.WebAPI.Controllers
{
    [Route("api")]
    public class PhoneController : Controller
    {
        private readonly IPersonService personSevice;

        public PhoneController(IPersonService personSevice)
        {
            this.personSevice = personSevice;
        }

        // GET api/{personId}/Phone
        [HttpGet("{personId}/Phone")]
        public ActionResult<Person> Get([FromRoute]int personId)
        {
            var resulte = personSevice.GetPersonPhoneList(personId);
            if (resulte == null || personId < 1)
            {
                return NotFound();
            }
            else
            {
                return Ok(resulte);
            }

        }

        // POST api/{personId}/Phone
        [HttpPost("{personId}/Phone")]
        public ActionResult Post([FromRoute]int personId, [FromBody]Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (phone == null)
                {
                    return NotFound();
                }
                else
                {
                    personSevice.AddPhoneForPerson(personId,phone);
                    string Uri = string.Format($"api/{0}/Phone",personId);                    
                    return Created(Uri,phone);
                }
            }
        }

        // PUT api/Phone/{id}
        [HttpPut("Phone/{id:Int}")]
        public ActionResult Put([FromRoute]int id, [FromBody]Phone phone)
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

        // DELETE api/Phone/{id}
        [HttpDelete("Phone/{id:Int}")]
        public ActionResult Delete([FromRoute]int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            else
            {
                personSevice.DeletePhoneForPerson(id);
                return NoContent();
            }

        }
    }
}
