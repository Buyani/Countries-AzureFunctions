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
using palota_func_countries_assessment.Models;
using System.Net;

namespace palota_func_countries_assessment.Functions
{
    public static class getByIsoCode
    {
        [FunctionName("getByIsoCode")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get","post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting one one country");
            try
            {
                string ISOCode = req.Query["isocode"];
                var responseMessage = await CountryRepo.Get(Environment.GetEnvironmentVariable("COUNTRIES_API_URL") + "/alpha/" + ISOCode);

                if (responseMessage != null)
                {
                    return new OkObjectResult(responseMessage);
                }
                return new
                {
                    HttpStatusCode.NotFound,
                    Message = "The country with ISO 3166 Alpha 3 code 'zar' could not be found."
                };

            }
            catch
            {
                throw new Exception("Error occured while trying to connect...");
            }
        }



    }
}
