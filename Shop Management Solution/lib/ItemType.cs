using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop_Management_Solution.lib
{
    class ItemType
    {
        private int itemId;
        private string itemName;
        private float price;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }    

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }      

        public float Price
        {
            get { return price; }
            set { price = value; }
        }


    }
}
