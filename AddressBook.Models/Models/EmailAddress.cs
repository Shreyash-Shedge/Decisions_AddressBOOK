using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models.Models
{
    public class EmailAddress
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? ContactId { get; set; } = Guid.NewGuid().ToString();
        public EmailType EmailType { get; set; }
        public string? Address { get; set; }
    }

    public enum EmailType
    {
        Work,
        Home,
        Other
    }
}
