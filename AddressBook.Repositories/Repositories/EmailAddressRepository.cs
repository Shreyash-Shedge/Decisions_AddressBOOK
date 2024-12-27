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
    public class EmailAddressRepository : IEmailAddressRepository
    {
        public void AddEmailAddress(EmailAddress emailAddress)
        {
            if (emailAddress == null)
            {
                throw new ArgumentNullException("EmailAddress does not exists");
            }

            if (!StaticContactData.Contacts.ContainsKey(emailAddress.ContactId!))
            {
                throw new KeyNotFoundException("Contact does not exists");
            }

            emailAddress.Id = Guid.NewGuid().ToString();
            StaticContactData.Contacts[emailAddress.ContactId!].EmailAddress.Add(emailAddress);
        }


        public void UpdateEmailAddress(EmailAddress emailAddress)
        {
            var contact = StaticContactData.Contacts.Values.FirstOrDefault(e => e.EmailAddress.Any(email => email.Id == emailAddress.Id));
            if (contact == null)
            {
                throw new KeyNotFoundException("EmailAddress does not exists");
            }

            var index = contact.EmailAddress.FindIndex(e => e.Id == emailAddress.Id);

            if (index == -1)
            {
                throw new KeyNotFoundException("EmailAddress does not exist");
            }
            contact.EmailAddress[index] = emailAddress;
        }

        public void DeleteEmailAddress(string emailId, string contactId)
        {
            var contact = StaticContactData.Contacts.Values.FirstOrDefault(contact => contact.Id == contactId);

            if (contact == null)
            {
                throw new ArgumentNullException($"{contactId} is not a contact");
            }

            var existingEmailAddress = contact.EmailAddress.FirstOrDefault(emailAddress => emailAddress.Id == emailId);
            if (existingEmailAddress == null)
            {
                throw new ArgumentNullException($"{emailId} is not a Email Address");
            }
            contact.EmailAddress.Remove(existingEmailAddress);
        }
    }
}
