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
using System.Text;
using Master.Models.ResponseModels;

namespace Master.Microservice
{
    public static class RemoveCustomerById
    {
        [FunctionName("RemoveCustomerById")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "RemoveCustomerById")] HttpRequest req,
            ILogger log)
        {
            try
            {
                MasterBusinessDomain masterBusinessDomain = new MasterBusinessDomain();
                string requestBody;
                using (StreamReader reader = new StreamReader(req.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                }
                int id = JsonConvert.DeserializeObject<int>(requestBody);
                Base result = masterBusinessDomain.RemoveCustomerById(id);
                string json = JsonConvert.SerializeObject(result);
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
