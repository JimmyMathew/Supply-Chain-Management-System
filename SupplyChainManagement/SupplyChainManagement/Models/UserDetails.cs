using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChainManagement.Models
{
    public class UserDetails
    {
        public long id { get; set; }
        public string name { get; set; }
        public string usename { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public string updatedBy { get; set; }
        public Nullable<System.DateTime> updatedOn { get; set; }
    }
}