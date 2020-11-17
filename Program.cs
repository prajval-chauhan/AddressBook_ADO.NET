using System;

namespace AddressBookADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book Program");
            AddressBook call = new AddressBook();
            call.CheckConnection();
        }
    }
}
