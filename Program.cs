using System;

namespace AddressBookADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book Program");
            AddressBook call = new AddressBook();
            ContactModel contact = new ContactModel("Edited", "Chauhan", "Nakur", "Saharanpur", "UP", 247342, 8193013027, "prajval.chauhan3@gmail.com");
            //call.CheckConnection();
            //call.CreateAddressBookTable();
            //call.EditContactUsingFirstName(contact, "p");
            //call.DeleteContact("Edited", "Chauhan");
            //call.DisplayContacts();
            call.FindingContactsByCityOrByState("Saharanpur");
        }
    }
}
