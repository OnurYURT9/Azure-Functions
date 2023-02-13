using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FirstFunction
{
    public static class MyHttpTrigger
    {
        [FunctionName("MyHttpTrigger")]
        public static async Task<IActionResult> GetProducts(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
			string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

           // Product product = JsonConvert.DeserializeObject<Product>(requestBody);

            dynamic data = JsonConvert.DeserializeObject(requestBody);
            

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult($"{data.Id}-{data.Name}-{data.Price}-{data.Category}");
        } 
        
        [FunctionName("MyHttpTrigger2")]
        public static IActionResult GetProductById(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Products/{id}")] HttpRequest req,
            ILogger log,int id)
        {
            log.LogInformation("Gelen id:"+id);
            return new OkResult();
        }
    }
}
