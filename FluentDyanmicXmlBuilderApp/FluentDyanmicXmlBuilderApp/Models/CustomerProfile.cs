using System;
using static FluentDyanmicXmlBuilderApp.Helpers.Enumerations;

namespace FluentDyanmicXmlBuilderApp.Models
{
    internal class CustomerProfile
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string DateOfBirth { get; set; }
    }
}
