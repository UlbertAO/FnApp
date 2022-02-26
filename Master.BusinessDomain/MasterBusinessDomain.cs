using Master.DataDomain;
using Master.Models.EntityModels;
using Master.Models.RequestModels;
using Master.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.BusinessDomain
{
    public class MasterBusinessDomain
    {
        private readonly MasterDataDomain masterDataDomain;

        public MasterBusinessDomain()
        {
            masterDataDomain = new MasterDataDomain();
        }
        public CustomerDetails GetCustomerById(int id)
        {
            return masterDataDomain.GetCustomerById(id);
        }
        public Base RemoveCustomerById(int id)
        {
            Base baseResult = new Base();
            var result = masterDataDomain.RemoveCustomerById(id);
            baseResult.isSucceed = result;
            if (result)
            {
                baseResult.message = "Customer Details are Removed";
            }
            else
            {
                baseResult.message = "Something Went Wrong While Removing Customer Data";
            }
            return baseResult;
        } 
        public List<CustomerDetails> GetCustomers()
        {
            return masterDataDomain.GetCustomers();
        }
        public Base SaveCustomerDetail(CustomerDetails customerDetails)
        {
            Base baseResult = new Base();
            var result = masterDataDomain.SaveCustomerDetail(customerDetails);
            baseResult.isSucceed = result;
            if (result)
            {
                baseResult.message = "Customer Details are Saved";
            }
            else
            {
                baseResult.message = "Something Went Wrong While Saving Customer Data";
            }
            return baseResult;
        }
        public Base UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            Base baseResult = new Base();
            var result = masterDataDomain.UpdateCustomerDetails(customerDetails);
            baseResult.isSucceed = result;
            if (result)
            {
                baseResult.message = "Customer Details are Updated";
            }
            else
            {
                baseResult.message = "Something Went Wrong While Updating Customer Data";
            }
            return baseResult;
        }
    }
}
