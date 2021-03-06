using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using palota_func_countries_assessment.Models;
using System.Collections.Generic;
using System.Net.Http;
using palota_func_countries_assessment.Processor;

namespace palota_func_countries_assessment.Functions
{
    public static class Borders
    {
        private static HttpClient httpClient = new HttpClient();
        [FunctionName("Borders")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "countries/{iso3Code}/borders")] HttpRequest req, string iso3Code ,
            ILogger log)
        {
            var boderingList = new List<CountryViewModel>(); 
            try
            {
                var url = Environment.GetEnvironmentVariable("COUNTRIES_API_URL") + "/all";
                var results = await httpClient.GetAsync(url);

                log.LogInformation($"Getting by border at Code{iso3Code}");
                log.LogInformation("API URL: " + url);
                log.LogInformation("IsSuccessStatusCode: " + results.IsSuccessStatusCode.ToString());

                if (!results.IsSuccessStatusCode )
                {
                    return new BadRequestObjectResult(new Response
                    {
                        Message = $"The country with ISO code {iso3Code}  could not be found."
                    });
                }
                var list= await ResponseProccessor.Get(results);
                boderingList = ResponseProccessor.BorderingCountries(list,iso3Code);
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message + "occured while trying to connect...");
            }

            return boderingList;
        }
    }
}
