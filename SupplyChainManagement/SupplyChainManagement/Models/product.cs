//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupplyChainManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string model { get; set; }
        public string sku { get; set; }
        public string upc { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> quantity { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public string updatedBy { get; set; }
        public Nullable<System.DateTime> updatedOn { get; set; }
    }
}
