using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;

namespace AddressBook.Repositories.Interfaces
{
    public interface IPhoneNumberRepository
    {
        void AddPhoneNumber (PhoneNumber phoneNumber );
        void UpdatePhoneNumber(PhoneNumber phoneNumber);
        void DeletePhoneNumber( string phoneNumberId, string contactId);
    }
}
