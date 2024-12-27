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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public Contact GetContactById(string id)
        {
            return _contactRepository.GetContactById(id);
        }

        public void AddContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
        }

        public void DeleteContact(string id)
        {
            _contactRepository.DeleteContact(id);
        }

        public void UpdateContact(string id, Contact contact)
        {
            contact.Id = id;
            _contactRepository.UpdateContact(id, contact);
        }

        public void AddMultipleContacts(List<Contact> contacts)
        {
            _contactRepository.AddMultipleContacts(contacts);
        }
    }
}
