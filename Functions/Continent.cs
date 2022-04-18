using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using palota_func_countries_assessment.Models;
using System.Collections.Generic;
using palota_func_countries_assessment.Processor;

namespace palota_func_countries_assessment.Functions
{
    public static class Continent
    {
        private static HttpClient httpClient = new HttpClient();
        [FunctionName("Continent")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function,nameof(HttpMethod.Get), Route = "continents/{continentName}/countries/")] HttpRequest req,string continentName,
            ILogger log)
        {
            var countriesList = new List<CountryViewModel>();
            try
            {
                var url = Environment.GetEnvironmentVariable("COUNTRIES_API_URL")+"/subregion/" + continentName;
                var results = await httpClient.GetAsync(url);

                log.LogInformation($"Getting by continent{continentName}");
                log.LogInformation("API URL: " + url);
                log.LogInformation("IsSuccessStatusCode: " + results.IsSuccessStatusCode.ToString());

                if (!results.IsSuccessStatusCode)
                {
                    return new BadRequestObjectResult(new Response
                    {
                        Message = $"The continent with name {continentName} could not be found."
                    });
                }

                countriesList = await ResponseProccessor.Get(results);
            }
            catch
            {
                throw new Exception("Error occured while trying to connect...");
            }
            return countriesList;
        }
    }
}
