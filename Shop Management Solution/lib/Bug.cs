using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop_Management_Solution.lib
{
    class Bug
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string module;

        public string Module
        {
            get { return module; }
            set { module = value; }
        }
        private string serverity;

        public string Serverity
        {
            get { return serverity; }
            set { serverity = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


    }
}
