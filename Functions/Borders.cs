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
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "countries/{iso3Code}/borders")] HttpRequest req, string iso3Code ,
            ILogger log)
        {
            log.LogInformation("Getting a list of countries by continent");
            try
            {
                var responseMessage = await CountryRepo.Get(Environment.GetEnvironmentVariable($"COUNTRIES_API_URL") + "/subregion/" +iso3Code);

                if (responseMessage != null)
                {
                    return new OkObjectResult(responseMessage);
                }
                return new NotFoundObjectResult($"The countries bodering at iso3Code {iso3Code} could not be found.");
            }
            catch
            {
                throw new Exception("Error occured while trying to connect...");
            }
        }
    }
}
