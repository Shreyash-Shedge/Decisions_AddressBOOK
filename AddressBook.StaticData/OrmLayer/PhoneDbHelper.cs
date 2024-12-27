using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBook.ORM.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AddressBook.ORM.OrmLayer
{
    public class PhoneDbHelper : IPhoneDbHelper
    {
        private readonly IGenericHelper _genericDbHelper;
        private readonly IDbHelper _dbHelper;

        public PhoneDbHelper(IGenericHelper genericHelper, IDbHelper dbHelper)
        {
            _genericDbHelper = genericHelper;
            _dbHelper = dbHelper;
        }
        public List<PhoneNumber> FetchPhonenumbersForContact(string contactId)
        {
            var contact = _dbHelper.FetchContactById(contactId);
            if (contact == null)
            {
                throw new ArgumentNullException("Contact object is null or empty");
            }

            string phoneNumberQuery = "SELECT * FROM PhoneNumbers Where IsDeleted=0 AND ContactId=@ContactId";
            var phoneNumbers = _genericDbHelper.FetchData<PhoneNumber>(phoneNumberQuery, MapPhoneNumber, new SqlParameter("@ContactId", contactId));

            return phoneNumbers;
        }
        private PhoneNumber FetchPhoneNumberById(string phoneNumberId)
        {
            string phoneNumberQuery = "SELECT * FROM Phonenumbers where Id=@Id";
            var phoneNumbers = _genericDbHelper.FetchData<PhoneNumber>(phoneNumberQuery, MapPhoneNumber, new SqlParameter("@Id", phoneNumberId));

            return phoneNumbers.FirstOrDefault()!;
        }
        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException("Phonenumber object cannot be null or empty");
            }

            string addPhoneQuery = "INSERT INTO Phonenumbers (Id, ContactId, PhoneType, Number)" +
                                                    "VALUES (@Id, @ContactId, @PhoneType, @Number);";

            _genericDbHelper.AddRecord(addPhoneQuery,
                new SqlParameter("@Id", phoneNumber.Id),
                new SqlParameter("@ContactId", phoneNumber.ContactId),
                new SqlParameter("@PhoneType", phoneNumber.PhoneType),
                new SqlParameter("@Number", phoneNumber.Number));
        }
        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException("Phonenumber object is null or does not exist");
            }
            string updatePhoneQuery = @"UPDATE Phonenumbers
                                           SET Number=@Number,
                                               PhoneType=@PhoneType
                                               Where Id=@Id AND ContactId=@ContactId";

            _genericDbHelper.UpdateRecord(updatePhoneQuery,
                new SqlParameter("@Id", phoneNumber.Id),
                new SqlParameter("@ContactId", phoneNumber.ContactId),
                new SqlParameter("@PhoneType", phoneNumber.PhoneType),
                new SqlParameter("@Number", phoneNumber.Number));
        }
        public void DeletePhoneNumber(string phoneId, string contactId)
        {
            var contact = _dbHelper.FetchContactById(contactId);
            if(contact == null)
            {
                throw new ArgumentNullException("Cannot object is null or empty");
            }
            var phoneNumber = FetchPhoneNumberById(phoneId);

            if (phoneNumber == null)
            {
                throw new ArgumentNullException("Cannot object is null or phone number does not exist");
            }
            string updatePhoneNumberQuery = "UPDATE PhoneNumbers SET IsDeleted = 1 WHERE Id = @Id AND ContactId=@ContactId";
            _genericDbHelper.DeleteRecord(updatePhoneNumberQuery, new SqlParameter("@Id", phoneId), new SqlParameter("@ContactId", contactId));
        }
        public void RestorePhoneNumber(string phoneNumberId, string contactId)
        {
            var phoneNumber = FetchPhoneNumberById(phoneNumberId);

            if (phoneNumber == null)
            {
                throw new ArgumentNullException("Object is null or phone number does not exist");
            }

            string updatePhoneNumberQuery = "UPDATE PhoneNumbers SET IsDeleted = 0 WHERE Id = @Id AND ContactId=@ContactId";
            _genericDbHelper.DeleteRecord(updatePhoneNumberQuery, new SqlParameter("@Id", phoneNumberId), new SqlParameter("@ContactId", contactId));
        }
        private PhoneNumber MapPhoneNumber(SqlDataReader reader)
        {
            return new PhoneNumber
            {
                Id = reader["Id"].ToString(),
                ContactId = reader["ContactId"].ToString(),
                Number = reader["Number"].ToString(),
                PhoneType = Enum.TryParse<PhoneType>(reader["PhoneType"].ToString(), out var phoneType) ? phoneType : PhoneType.Other
            };
        }
       
    }
}
