using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBook.Repositories.Interfaces;
using AddressBook.Services.Interfaces;

namespace AddressBook.Services.Services
{
    public class EmailAddressService : IEmailAddressService
    {

        private readonly IEmailAddressRepository _emailAddressRepository;

        public EmailAddressService(IEmailAddressRepository emailAddressRepository)
        {
            _emailAddressRepository = emailAddressRepository;
        }
        public void AddEmailAddress(EmailAddress emailAddress)
        {
            _emailAddressRepository.AddEmailAddress(emailAddress);
        }

        public void UpdateEmailAddress(EmailAddress emailAddress)
        {
            _emailAddressRepository.UpdateEmailAddress(emailAddress);
        }

        public void DeleteEmailAddress(string emailId, string contactId)
        {
            _emailAddressRepository.DeleteEmailAddress(emailId, contactId);
        }
    }
}
