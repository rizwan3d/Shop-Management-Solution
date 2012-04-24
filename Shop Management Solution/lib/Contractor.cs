using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop_Management_Solution.lib
{
    class Contractor
    {
        public Contractor(int id, String name, String email, String phone, String mobile, String addressLine1, String addresLine2, String postCode, int country, String city)            
        {
            _id = id;
            _name = name;
            _phone = phone;
            _mobile = mobile;
            _addressLine1 = addressLine1;
            _addressLine2 = addresLine2;
            _postCode = postCode;
            _country = country;
            _city = city;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private String _phone;

        public String  Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private String _mobile;

        public String Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private String _addressLine1;

        public String  AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }

        private String _addressLine2;

        public String AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }

        private String _postCode;

        public String PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        private int _country;

        public int Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private String _city;

        public String City
        {
            get { return _city; }
            set { _city = value; }
        }
        
    }
}
