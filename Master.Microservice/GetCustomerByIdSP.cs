using System;
using System.IO;
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

namespace Master.Microservice
{
    public static class GetCustomerByIdSP
    {
        [FunctionName("GetCustomerByIdSP")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "GetCustomerByIdSP")] HttpRequest req,
            ILogger log)
        {
            try
            {
                MasterSPBusinessDomain masterSPBusinessDomain = new MasterSPBusinessDomain();
                string requestBody;
                using (StreamReader reader = new StreamReader(req.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                }
                int id = JsonConvert.DeserializeObject<int>(requestBody);
                CustomerDetails customer = masterSPBusinessDomain.GetCustomerById(id);
                string json = JsonConvert.SerializeObject(customer);
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
