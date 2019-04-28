using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChainManagement.Models
{
    public class ManufacturerUnitDetails
    {
        public long id { get; set; }
        public string name { get; set; }
        public string productname { get; set; }
        public Nullable<long> productid { get; set; }
        public Nullable<int> quantity { get; set; }
        public string createdOn { get; set; }
    }
}