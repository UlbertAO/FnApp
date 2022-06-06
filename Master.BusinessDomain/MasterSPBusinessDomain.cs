using System;
using System.Collections.Generic;
using Master.DataDomain;
using Master.Models.EntityModels;

namespace Master.BusinessDomain
{
    public class MasterSPBusinessDomain
    {
        private readonly MasterSPDataDomain masterSPDataDomain;

        public MasterSPBusinessDomain()
        {
            masterSPDataDomain = new MasterSPDataDomain();
        }
        public List<CustomerDetails> GetCustomers()
        {
            return masterSPDataDomain.GetCustomers();
        }

        public CustomerDetails GetCustomerById(int id)
        {
            return masterSPDataDomain.GetCustomerById(id);
        }
    }
}
