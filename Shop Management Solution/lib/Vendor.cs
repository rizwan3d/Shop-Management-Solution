using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop_Management_Solution.lib
{
    class Vendor
    {
        public Vendor()
        {
 
        }

        public Vendor(int id, string name, string email, string phoneNo, string mobileNo, string location)
        {
            _id = id;
            _name = name;
            _phoneNo = phoneNo;
            _mobileNo = mobileNo;            
            _location = location;
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _mobileNo;

        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }
        private string _phoneNo;

        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }
        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }



    }
}
