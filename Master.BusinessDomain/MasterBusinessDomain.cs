using Master.DataDomain;
using Master.Models.EntityModels;
using Master.Models.RequestModels;
using Master.Models.ResponseModels;
using Master.Utilities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.BusinessDomain
{
    public class MasterBusinessDomain
    {
        private readonly MasterDataDomain masterDataDomain;
        private static readonly IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

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
            bool isCached = memoryCache.TryGetValue(CacheMemories.AllCustomers.ToString(), out List<CustomerDetails> customerDetails);
            if(isCached)
            {
                customerDetails = memoryCache.Get(CacheMemories.AllCustomers.ToString()) as List<CustomerDetails>;
            }
            else
            {
                customerDetails = masterDataDomain.GetCustomers();
                var cacheExpiry = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(2));
                memoryCache.Set(CacheMemories.AllCustomers.ToString(), customerDetails, cacheExpiry);
            }

            return customerDetails;
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
