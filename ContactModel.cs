using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO.NET
{
    public class ContactModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public double phoneNo { get; set; }
        public string email { get; set; }
    }
}
