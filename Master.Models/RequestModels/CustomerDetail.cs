using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Models.RequestModels
{
    public class CustomerDetail
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }
}
