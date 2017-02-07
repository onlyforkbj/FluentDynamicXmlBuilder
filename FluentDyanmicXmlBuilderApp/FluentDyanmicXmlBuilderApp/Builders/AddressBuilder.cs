using FluentDyanmicXmlBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentDyanmicXmlBuilderApp.Builders
{
    internal class AddressBuilder
    {
        private readonly Address address = new Address
        {
            City = "Chicago",
            Country = "United States",
            CustomerId = new Guid("a65544d5-d35d-4d72-ba40-12f35347fdf0"),
            ZipCode = "111253",
            Line1 = "Chicago Main Street",
            Line2 = "Chicago Down Town"
        };

        private AddressBuilder()
        {

        }

        public static AddressBuilder Create()
        {
            return new AddressBuilder();
        }

        public AddressBuilder ForCustomerId(string customerId)
        {
            address.CustomerId = Guid.Parse(customerId);
            return this;
        }

        public AddressBuilder WithAddressLine1(string addressLine1)
        {
            address.Line1 = addressLine1;
            return this;
        }

        public AddressBuilder WithAddressLine2(string addressLine2)
        {
            address.Line2 = addressLine2;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            address.City = city;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            address.Country = country;
            return this;
        }

        public AddressBuilder WithZipCode(string zipCode)
        {
            address.ZipCode = zipCode;
            return this;
        }

        public Address Build()
        {
            return address;
        }

        public Address BuildNewAddress()
        {
            return new Address();
        }
    }
}
