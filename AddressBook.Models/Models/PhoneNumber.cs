using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models.Models
{
    public class PhoneNumber
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? ContactId { get; set; } = Guid.NewGuid().ToString();

        [MinLength(10)]
        public string? Number { get; set; }
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Home,
        Work,
        Mobile,
        Other
    }
}
