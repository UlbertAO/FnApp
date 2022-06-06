using System;
using System.Collections.Generic;
using System.Linq;
using Master.EntityFramework;
using Master.Models.EntityModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Master.DataDomain
{
    public class MasterSPDataDomain
    {
        private readonly MyDbContext context;

        public MasterSPDataDomain()
        {
            context = new MyDbContext();
        }
        public List<CustomerDetails> GetCustomers()
        {
            List<CustomerDetails> customers = context.RunFromSqlRaw<CustomerDetails>("exec [dbo].[getAllCustomers]").AsNoTracking().ToList();
            return customers;
        }

        public CustomerDetails GetCustomerById(int id)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id",id)
            };
            CustomerDetails customer = context.RunFromSqlRaw<CustomerDetails>("exec [dbo].[getCustomersById] @id",sqlParameters).AsNoTracking().ToList().FirstOrDefault();
            return customer;
        }
    }
}
