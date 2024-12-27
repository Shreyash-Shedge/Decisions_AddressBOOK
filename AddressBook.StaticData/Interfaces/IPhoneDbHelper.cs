using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;

namespace AddressBook.ORM.Interfaces
{
    public interface IPhoneDbHelper
    {
        List<PhoneNumber> FetchPhonenumbersForContact(string contactId);
        void AddPhoneNumber(PhoneNumber phoneNumber);
        void UpdatePhoneNumber(PhoneNumber phoneNumber);
        void DeletePhoneNumber(string phoneId, string contactId);
        void RestorePhoneNumber(string phoneNumberId, string contactId);
    }
}
