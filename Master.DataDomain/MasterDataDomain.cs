using Master.EntityFramework;
using Master.Models.EntityModels;
using Master.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Master.DataDomain
{
    public class MasterDataDomain
    {
        private readonly MyDbContext context;

        public MasterDataDomain()
        {
            context = new MyDbContext();
        }

        public CustomerDetails GetCustomerById(int id)
        {
            CustomerDetails customer = (from cust in context.CustomerDetails
                                     where cust.customerId == id
                                     select cust).FirstOrDefault();
            return customer;
        }
        public bool RemoveCustomerById(int id)
        {
            try
            {

                CustomerDetails customer = (from cust in context.CustomerDetails
                                            where cust.customerId == id
                                            select cust).FirstOrDefault();
                context.Remove(customer);
                context.SaveChanges();

            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }
        public List<CustomerDetails> GetCustomers()
        {
            List<CustomerDetails> customers = (from cust in context.CustomerDetails
                                     select cust).ToList();
            return customers;
        }
        public bool SaveCustomerDetail(CustomerDetails customerDetails)
        {
            try
            {
                context.CustomerDetails.Add(customerDetails);
                context.SaveChanges();
            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            try
            {
                CustomerDetails customer = (from cust in context.CustomerDetails
                                            where cust.customerId == customerDetails.customerId
                                            select cust).FirstOrDefault();
                if (customer != null)
                {
                    customer.firstName = customerDetails.firstName;
                    customer.lastName = customerDetails.lastName;
                    customer.phone = customerDetails.phone;
                    customer.email = customerDetails.email;
                    customer.street = customerDetails.street;
                    customer.city = customerDetails.city;
                    customer.state = customerDetails.state;
                    customer.zipCode = customerDetails.zipCode;
                    context.SaveChanges();
                }
            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }
    }
}
