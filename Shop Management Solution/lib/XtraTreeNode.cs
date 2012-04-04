using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop_Management_Solution.lib
{
    class XtraTreeNode
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string mobileNo;

        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }
        private string contactNo;

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }
        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private XtraTreeNode parent;

        internal XtraTreeNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private XtraNodeType nodeType;

        internal XtraNodeType NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }



    }
}
