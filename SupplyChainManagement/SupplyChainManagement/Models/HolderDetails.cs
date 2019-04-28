using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChainManagement.Models
{
    public class HolderDetails
    {
        public long id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createOn { get; set; }
        public string updateBy { get; set; }
        public Nullable<System.DateTime> updateOn { get; set; }
    }
}