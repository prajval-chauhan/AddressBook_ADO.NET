using System;

namespace AddressBookADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book Program");
            AddressBook call = new AddressBook();
            ContactModel contact = new ContactModel("Prajval", "Chauhan", "Nakur", "Saharanpur", "UP", 247342, 8193013027, "prajval.chauhan3@gmail.com");
            //call.CheckConnection();
            //call.CreateAddressBookTable();
            call.AddContact(contact);
        }
    }
}
