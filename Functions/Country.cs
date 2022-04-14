using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using palota_func_countries_assessment.CountryRepository;
using System.Net;

namespace palota_func_countries_assessment.Functions
{
    public static class Country
    {
        [FunctionName("Country")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get",Route = "countries")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting a list of countries");
            try
            {
                var responseMessage = await CountryRepo.Get(Environment.GetEnvironmentVariable("COUNTRIES_API_URL")+"/all");

                if(responseMessage != null)
                {
                    return new OkObjectResult(responseMessage);
                }

                return new NotFoundObjectResult("No countries were found");
            }
            catch
            {
                throw new Exception("Error occured while trying to connect...");
            }

        }




    }
}
