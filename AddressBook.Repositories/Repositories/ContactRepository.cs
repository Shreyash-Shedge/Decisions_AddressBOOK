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
    public class ContactRepository : IContactRepository
    {
        public IEnumerable<Contact> GetAllContacts()
        {
            Dictionary<string, Contact>.ValueCollection values = StaticContactData.Contacts.Values;

            if(values == null)
            {
                throw new Exception("Static List is empty");
            }
            return values;
        }

        public Contact GetContactById(string id)
        {
            var contact = StaticContactData.Contacts.Values.FirstOrDefault(x => x.Id == id);
            
            if(contact == null)
            {
                throw new KeyNotFoundException($"{id} is not a contact");
            }
            return contact!;
        }

        public void AddContact(Contact contact)
        {
            if(contact == null)
            {
                throw new ArgumentNullException("Contact object is null");
            }
            StaticContactData.Contacts[contact.Id!] = contact;
        }

        public void DeleteContact(string id)
        {
            StaticContactData.Contacts.Remove(id);
        }

        public void UpdateContact(string id, Contact contact)
        {
            if (!StaticContactData.Contacts.ContainsKey(id))
            {
               throw new KeyNotFoundException($"{id} is not a contact");
            }
            StaticContactData.Contacts[id] = contact;
        }
        public void AddMultipleContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                StaticContactData.Contacts[contact.Id!] = contact;
            }
        }
    }
}
