using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Master.BusinessDomain;
using Master.Models.EntityModels;
using System.Text;
using System.Collections.Generic;

namespace Master.Microservice
{
    public static class GetAllCustomers
    {
        [FunctionName("GetAllCustomers")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetAllCustomers")] HttpRequest req,
            ILogger log)
        {
            try
            {
                MasterBusinessDomain masterBusinessDomain = new MasterBusinessDomain();

                List<CustomerDetails> customers = masterBusinessDomain.GetCustomers();
                string json = JsonConvert.SerializeObject(customers);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}

