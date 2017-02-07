﻿using System;

namespace FluentDyanmicXmlBuilderApp.Models
{
    public class Address
    {
        public Guid CustomerId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}