using API.DTOs;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // Inject JsonContactService
        private readonly JsonFileService _contactService;

        public ContactsController(JsonFileService contactService)
        {
            _contactService = contactService;
        }

        // CRUD HTTP Requests Handler

        // Create a read contact http get request handler
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_contactService.GetContacts());
        }

        // Create a read single contact http get request handler
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var contact = _contactService.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // Create a create contact http post request handler
        [HttpPost]
        public ActionResult Post([FromBody] CreateContactDTO contact)
        {
            var createdContact = _contactService.AddContact(contact);
            
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdContact.Id, contact);
        }

        // Create an update contact http put request handler
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] UpdateContactDTO contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            var existingContact = _contactService.GetContact(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            _contactService.UpdateContact(contact);
            return Ok(contact);
        }

        // Create a delete contact http delete request handler
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingContact = _contactService.GetContact(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            _contactService.DeleteContact(id);
            return Ok();
        }
    }
}
