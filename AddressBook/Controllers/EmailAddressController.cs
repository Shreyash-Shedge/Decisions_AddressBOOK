using AddressBook.Models.Models;
using AddressBook.ORM.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAddressController : ControllerBase
    {
        private readonly IEmailDbHelper _dbHelper;
        public EmailAddressController(IEmailDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IActionResult FetchEmailsForContact(string contactId)
        {
            var emails = _dbHelper.FetchEmailsForContact(contactId);
            return Ok(emails);
        }
        [HttpPost]
        public IActionResult AddEmailAddress(EmailAddress emailAddress)
        {
            _dbHelper.AddEmailAddress(emailAddress);
            return Created();
        }

        [HttpPut]
        public IActionResult UpdateEmailAddress(EmailAddress emailAddress)
        {
            _dbHelper.UpdateEmailAddress(emailAddress);
            return NoContent();
        }

        [HttpDelete("{emailId}/{contactId}")]
        public IActionResult DeletePhoneNumber(string emailId, string contactId)
        {
            _dbHelper.DeleteEmailAddress(emailId, contactId);
            return NoContent();
        }

        [HttpPut("/RestoreEmail")]
        public IActionResult RestoreEmailAddress(string emailId, string contactId)
        {
            _dbHelper.RestoreEmailAddress(emailId, contactId);
            return NoContent();
        }
    }
}
