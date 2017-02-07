using FluentDyanmicXmlBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static FluentDyanmicXmlBuilderApp.Helpers.Enumerations;

namespace FluentDyanmicXmlBuilderApp.Builders
{
    internal class CustomerProfileBuilder
    {
        private readonly CustomerProfile customer = new CustomerProfile
        {
            Address = AddressBuilder.Create().Build(),
            CustomerId = new Guid("a65544d5-d35d-4d72-ba40-12f35347fdf0"),
            Age = 33,
            DateOfBirth = "22-Nov-1982",
            FirstName = "Lorem",
            LastName = "Ipsum",
            Gender = Gender.Female,
            SocialSecurityNumber = "831282-89567"
        };

        private CustomerProfileBuilder()
        {

        }

        public static CustomerProfileBuilder Create()
        {
            return new CustomerProfileBuilder();
        }

        public CustomerProfileBuilder ForCustomerId(string customerId)
        {
            customer.CustomerId = Guid.Parse(customerId);
            return this;
        }

        public CustomerProfileBuilder WithFirstName(string firstName)
        {
            customer.FirstName = firstName;
            return this;
        }

        public CustomerProfileBuilder WithLastName(string lastName)
        {
            customer.LastName = lastName;
            return this;
        }

        public CustomerProfileBuilder WithAge(int age)
        {
            customer.Age = age;
            return this;
        }

        public CustomerProfileBuilder WithGender(Gender gender)
        {
            customer.Gender = gender;
            return this;
        }

        public CustomerProfileBuilder WithSSN(string ssn)
        {
            customer.SocialSecurityNumber = ssn;
            return this;
        }

        public CustomerProfileBuilder WithAddress(Address address)
        {
            customer.Address = address;
            return this;
        }

        public CustomerProfile Build()
        {
            return customer;
        }

        public CustomerProfile BuildNewCustomer()
        {
            return new CustomerProfile();
        }
    }
}
