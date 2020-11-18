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
        public ContactModel() { }
        public ContactModel(string fn, string ln, string add, string city, string state, int zip, double phoneNo, string email)
        {
            this.firstName = fn;
            this.lastName = ln;
            this.address = add;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNo = phoneNo;
            this.email = email;
        }
    }
}
