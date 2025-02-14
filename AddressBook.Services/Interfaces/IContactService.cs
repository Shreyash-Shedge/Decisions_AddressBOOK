﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;

namespace AddressBook.Services.IServices
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(string id);
        void AddContact(Contact contact);
        void UpdateContact(string id, Contact contact);
        void DeleteContact(string id);
        void AddMultipleContacts(List<Contact> contacts);
    }
}
