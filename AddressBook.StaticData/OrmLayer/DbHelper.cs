using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBook.ORM.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AddressBook.ORM.OrmLayer
{
    public class DbHelper : IDbHelper
    {
        private readonly IGenericHelper _genericDbHelper;

        public DbHelper(IGenericHelper genericDbHelper)
        {
            _genericDbHelper = genericDbHelper;
        }

        public List<Contact> FetchAllContacts()
        {
            List<Contact> contacts = new List<Contact>();

            try
            {
                string contactQuery = "SELECT * FROM Contacts";
                contacts = _genericDbHelper.FetchData<Contact>(contactQuery, MapContact);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while fetching contact data from Database" + ex.Message);
            }
            return contacts;
        }

        public Contact FetchContactById(string contactId)
        {
            string contactQuery = "SELECT * FROM Contacts where Id=@Id";
            var contacts = _genericDbHelper.FetchData<Contact>(contactQuery, MapContact, new SqlParameter("@Id", contactId));

            return contacts.FirstOrDefault()!;
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("Contact Object cannot be null or Empty");
            }

            string contactQuery = "INSERT INTO Contacts (Id, Title, FirstName, LastName, MiddleName, Age, DateOfBirth, Gender, Category) " +
                                  "VALUES (@Id, @Title, @FirstName, @LastName, @MiddleName, @Age, @DateOfBirth, @Gender, @Category);";

            _genericDbHelper.AddRecord(contactQuery,
                new SqlParameter("@Id", contact.Id),
                new SqlParameter("@Title", contact.Title),
                new SqlParameter("@FirstName", contact.FirstName),
                new SqlParameter("@LastName", contact.LastName),
                new SqlParameter("@MiddleName", contact.MiddleName),
                new SqlParameter("@Age", contact.Age),
                new SqlParameter("@DateOfBirth", contact.DateOfBirth),
                new SqlParameter("@Gender", contact.Gender),
                new SqlParameter("@Category", contact.Category));
        }

        public void UpdateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("Contact Object cannot be null or Empty");
            }
           
            string updateContactQuery = @"UPDATE Contacts
                                          SET  Title=@Title, 
                                               FirstName=@FirstName, 
                                               LastName=@LastName, 
                                               MiddleName=@MiddleName, 
                                               Age=@Age, 
                                               DateOfBirth=@DateOfBirth,
                                               Gender=@Gender, 
                                               Category=@Category 
                                               Where Id=@Id";

            _genericDbHelper.UpdateRecord(updateContactQuery,
                new SqlParameter("@Title",contact.Title),
                new SqlParameter("@FirstName", contact.FirstName),
                new SqlParameter("@LastName", contact.LastName),
                new SqlParameter("@MiddleName", contact.MiddleName),
                new SqlParameter("@Age", contact.Age),
                new SqlParameter("@DateOfBirth", contact.DateOfBirth),
                new SqlParameter("@Gender", contact.Gender),
                new SqlParameter("@Category", contact.Category),
                new SqlParameter("@Id", contact.Id));
        }

        public void DeleteContact(string contactId)
        {
            var contact = FetchContactById(contactId);

            if(contact == null)
            {
                throw new ArgumentNullException("Cannot object is null or contact does not exist");
            } 

            string deleteContactQuery = "DELETE FROM Contacts Where Id=@Id";
            _genericDbHelper.DeleteRecord(deleteContactQuery, new SqlParameter("@Id", contactId));
        }

        // Helper Methods for Maping the data
        private Contact MapContact(SqlDataReader reader)
        {
            return new Contact
            {
                Id = reader["Id"].ToString(),
                Title = reader["Title"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                MiddleName = reader["MiddleName"].ToString(),
                Age = Convert.ToInt32(reader["Age"]),
                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                Gender = Enum.TryParse<Gender>(reader["Gender"].ToString(), out var gender) ? gender : Gender.Unknown,
                Category = Enum.TryParse<ContactCategory>(reader["Category"].ToString(), out var category) ? category : ContactCategory.Other,
                PhoneNumbers = new List<PhoneNumber>(),
                EmailAddress = new List<EmailAddress>(),
            };
        }
    }
}
