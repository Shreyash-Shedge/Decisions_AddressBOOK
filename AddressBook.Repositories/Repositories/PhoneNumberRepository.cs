using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBook.Repositories.Interfaces;
using AddressBook.StaticData;

namespace AddressBook.Repositories.Repositories
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException("Phonenumber does not exist");
            }

            if (!StaticContactData.Contacts.ContainsKey(phoneNumber.ContactId!))
            {
                throw new KeyNotFoundException("Contact with given Id does not exist");
            }

            phoneNumber.Id = Guid.NewGuid().ToString();
            StaticContactData.Contacts[phoneNumber.ContactId!].PhoneNumbers.Add(phoneNumber);
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            var contact = StaticContactData.Contacts.Values.FirstOrDefault(c => c.PhoneNumbers.Any(p => p.Id == phoneNumber.Id));

            if (contact == null)
            {
                throw new KeyNotFoundException("Phone number does not Exist");
            }

            var index = contact.PhoneNumbers.FindIndex(p => p.Id == phoneNumber.Id);

            if (index == -1)
            {
                throw new KeyNotFoundException("Phone number not found");
            }
            contact.PhoneNumbers[index] = phoneNumber;
        }

        public void DeletePhoneNumber(string phoneNumberId, string contactId)
        {
            var contact = StaticContactData.Contacts.Values.FirstOrDefault(contact => contact.Id == contactId);
            if (contact == null)
            {
                throw new ArgumentNullException($"{contactId} is not a contact");
            }

            var existingPhoneNumber = contact.PhoneNumbers.FirstOrDefault(phoneNumber => phoneNumber.Id == phoneNumberId);

            if (existingPhoneNumber == null)
            {
                throw new ArgumentNullException($"{phoneNumberId} is not a PhoneNumber");
            }
            contact.PhoneNumbers.Remove(existingPhoneNumber);
        }
    }
}
