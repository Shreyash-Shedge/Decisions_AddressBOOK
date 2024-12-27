using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBook.Repositories.Interfaces;
using AddressBook.Services.IServices;

namespace AddressBook.Services.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {

        public readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberService(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            _phoneNumberRepository.AddPhoneNumber(phoneNumber);
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            _phoneNumberRepository.UpdatePhoneNumber(phoneNumber);
        }

        public void DeletePhoneNumber(string phoneNumberId, string contactId)
        {
            _phoneNumberRepository.DeletePhoneNumber(phoneNumberId, contactId);
        }
    }
}
