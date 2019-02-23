using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChainManagement.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public long ReturnId { get; set; }
        public string Message { get; set; }

    }
}