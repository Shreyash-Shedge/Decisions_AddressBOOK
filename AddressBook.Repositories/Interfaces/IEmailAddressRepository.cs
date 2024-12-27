using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;

namespace AddressBook.Repositories.Interfaces
{
    public interface IEmailAddressRepository
    {
        void AddEmailAddress(EmailAddress emailAddress);
        void UpdateEmailAddress(EmailAddress emailAddress);
        void DeleteEmailAddress(string emailId, string contactId);
    }
}
