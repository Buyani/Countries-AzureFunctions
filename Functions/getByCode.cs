using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using palota_func_countries_assessment.Models;
using System.Collections.Generic;
using System.Net.Http;
using palota_func_countries_assessment.Processor;

namespace palota_func_countries_assessment.Functions
{
    public static class getByCode
    {
        private static HttpClient httpClient = new HttpClient();
        [FunctionName("getByCode")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethod.Get), Route = "countries/{iso3Code}")] HttpRequest req, string iso3Code,
            ILogger log)
        {
            var countriesList = new List<CountryViewModel>();
            try
            {
                    var url = Environment.GetEnvironmentVariable("COUNTRIES_API_URL")+"/alpha/" + iso3Code;
                    var results = await httpClient.GetAsync(url);

                    log.LogInformation($"Getting by ISo3Code{iso3Code}");
                    log.LogInformation("API URL: " + url);
                    log.LogInformation("IsSuccessStatusCode: " + results.IsSuccessStatusCode.ToString());

                    if (!results.IsSuccessStatusCode)
                    {
                        return new BadRequestObjectResult(new Response
                        {
                            Message = $"The country with ISO 3166 Alpha 3 code {iso3Code}  could not be found."
                        });
                    }

                    countriesList = await ResponseProccessor.Get(results);

                }
            catch (Exception ex)
            {
                throw new Exception("Error"+ex.Message+"occured while trying to connect...");
            }
            return countriesList[0];
        }



    }
}
