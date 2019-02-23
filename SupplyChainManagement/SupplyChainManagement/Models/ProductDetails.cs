using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChainManagement.Models
{
    public class ProductDetails
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string model { get; set; }
        public string sku { get; set; }
        public string upc { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable <int> quantity { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> updatedOn { get; set; }
    }
}