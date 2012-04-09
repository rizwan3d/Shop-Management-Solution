using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop_Management_Solution.lib
{
    class Sale
    {
        private long itemTypeId;        
        private string itemName;        
        private long quantity;      
        private double salePrice;
        private string uomName;

        public string UomName
        {
            get { return uomName; }
            set { uomName = value; }
        }


        public long ItemTypeId
        {
            get { return itemTypeId; }
            set { itemTypeId = value; }
        }
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public long Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        }



    }
}
