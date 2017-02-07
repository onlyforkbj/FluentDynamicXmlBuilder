using FluentDyanmicXmlBuilderApp;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Exploration of the Uber Cool Fluent Dynamic Xml Builder...");

        Console.WriteLine(BuildXmlDynamically().ToString());
        Console.ReadKey();
    }

    private static string BuildXmlDynamically()
    {
        dynamic returnXml = new XmlBuilder();

        returnXml.Customers = string.Empty;
        var customer = returnXml.Customers.Customer;
        customer.FirstName = "Balaji";
        customer.LastName = "Kuppusamy";
        customer.Age = 33;
        customer.Gender = 1;
        customer.DateOfBirth = "23-Dec-1983";
        customer["Nationality"] = "Indien";
        return returnXml.ToString();
    }
}