using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models.Models
{
    public class Contact
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public ContactCategory Category { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber> { };
        public List<EmailAddress> EmailAddress { get; set; } = new List<EmailAddress> { };
    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }

    public enum ContactCategory
    {
        Business,
        Family,
        Other
    }
}
