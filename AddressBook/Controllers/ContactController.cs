using AddressBook.Models.Models;
using AddressBook.ORM.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IDbHelper _dbHelper;

        public ContactController(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IActionResult FetchAllContacts()
        {
            var contacts = _dbHelper.FetchAllContacts();
            return contacts == null ? NotFound() : Ok(contacts);
        }

        [HttpGet("{contactId}")]
        public IActionResult FetchContactById(string contactId)
        {
            var contact = _dbHelper.FetchContactById(contactId);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact); 
        }

        [HttpPost]
        public IActionResult AddContactDetails(Contact contact)
        {
           _dbHelper.AddContact(contact);
            return Created();
        }

        [HttpPut]   
        public IActionResult UpdateContactDetails(Contact contact)
        {
           _dbHelper.UpdateContact(contact);
            return NoContent();
        }

        [HttpDelete("{contactId}")]
        public IActionResult DeleteContact(string contactId)
        {
            _dbHelper.DeleteContact(contactId);
            return NoContent();
        }
    }
}
