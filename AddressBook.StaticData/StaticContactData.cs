using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;

namespace AddressBook.StaticData
{
    public static class StaticContactData
    {
        public static Dictionary<string, Contact> Contacts { get; set; } = new Dictionary<string, Contact>()
        {
            {
            "1",
            new Contact()
            {
                Id = "1",
                Title = "Mr.",
                FirstName = "Shreyash",
                LastName = "Shedge",
                MiddleName = "Anil",
                Age = 22,
                DateOfBirth = new DateTime(2002, 2, 17),
                Gender = Gender.Male,
                Category = ContactCategory.Business,
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ContactId = "1",
                        PhoneType = PhoneType.Mobile,
                        Number = "9082392959"
                    }
                },
                EmailAddress = new List<EmailAddress>
                {
                    new EmailAddress()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ContactId = "1",
                        EmailType = EmailType.Work,
                        Address = "shreyash.shedge@decisions.com"
                    }
                }
            }
            }
        };
    }
}
