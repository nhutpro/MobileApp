using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    class Orders
    {
        public string ORDERID { get; set; }
        public string PRODUCTID { get; set; }
         public int NUMBER { get; set; }
        public DateTime ORDERDATE { get; set; }
        public string STATUS { get; set; }
        public string NAME { get; set;  }
        public string IMAGE { get; set; }
        public string BRAND { get; set;  }
        public float PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public int STOCK { get; set; }
        public string TYPE { get; set; }

    }
}
