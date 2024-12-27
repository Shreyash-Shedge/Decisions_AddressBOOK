using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;

namespace AddressBook.ORM.Interfaces
{
    public interface IEmailDbHelper
    {
        List<EmailAddress> FetchEmailsForContact(string contactId);
        void AddEmailAddress(EmailAddress emailAddress);
        void UpdateEmailAddress(EmailAddress emailAddress);
        void DeleteEmailAddress(string emailId, string contactId);
    }
}
