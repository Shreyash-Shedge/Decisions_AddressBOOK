using AddressBook.Models.Models;
using AddressBook.ORM.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneDbHelper _dbHelper;

        public PhoneNumberController(IPhoneDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IActionResult FetchPhonenumbersForContact(string contactId)
        {
            var phoneNumbers = _dbHelper.FetchPhonenumbersForContact(contactId);
            return Ok(phoneNumbers);
        }

        [HttpPost]
        public IActionResult AddPhoneNumber(PhoneNumber phoneNumber)
        {
           _dbHelper.AddPhoneNumber(phoneNumber);
            return Created();
        }

        [HttpPut]
        public IActionResult UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            _dbHelper.UpdatePhoneNumber(phoneNumber);
            return NoContent();
        }

        [HttpDelete("{phoneNumberId}/{contactId}")]
        public IActionResult DeletePhoneNumber(string phoneNumberId, string contactId)
        {
            _dbHelper.DeletePhoneNumber(phoneNumberId, contactId);
            return NoContent();
        }

        [HttpPut("/RestoreNumber")]
        public IActionResult RestorePhoneNumber(string phoneNumberId, string contactId)
        {
            _dbHelper.RestorePhoneNumber(phoneNumberId, contactId);
            return NoContent();
        }
    }
}
