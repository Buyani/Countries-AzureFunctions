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

namespace palota_func_countries_assessment.Functions
{
    public static class Borders
    {
        [FunctionName("Borders")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting a list of countries by borders");
            var responseMessage = await CountryRepo.Get("https://restcountries.com/v3.1/subregion/europe");

            return new OkObjectResult(responseMessage);
        }
    }
}
