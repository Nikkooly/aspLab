using PhoneRepository;
using PhoneRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace mvcBuiko.Controllers
{
    public class WebApiController : ApiController
    {
        IPhoneDictionary repository;
        public WebApiController()
        {
            repository = new PhonesRepository();
        }

        public List<Contact> GetContacts()
        {
            return repository.getAll();
        }


        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact Contact = repository.getById(id);
            if (Contact == null)
            {
                return NotFound();
            }

            return Json(Contact);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }
            repository.update(contact);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiContact
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repository.add(contact);
            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        // DELETE: api/ApiContact/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = repository.getById(id);
            if (contact == null)
            {
                return NotFound();
            }
            repository.delete(id);
            return Ok(contact);
        }
    }
}
