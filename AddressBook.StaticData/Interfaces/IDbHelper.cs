using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;

namespace AddressBook.ORM.Interfaces
{
    public interface IDbHelper
    {
        List<Contact> FetchAllContacts();
        Contact FetchContactById(string contactId);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(string contactId);
    }
}
