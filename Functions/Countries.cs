using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using palota_func_countries_assessment.Models;
using System.Net.Http;
using palota_func_countries_assessment.Processor;

namespace palota_func_countries_assessment.Functions
{
    public static class Country
    {
        private static HttpClient httpClient = new HttpClient();
        [FunctionName("Country")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethod.Get), Route = "countries")] HttpRequest req,
            ILogger log)
        {
          
            var  countriesList = new List<CountryViewModel>();
            try
            {
                var url = Environment.GetEnvironmentVariable("COUNTRIES_API_URL") + "/all";
                var results = await httpClient.GetAsync(url);

                log.LogInformation("Getting a list of countries");
                log.LogInformation("API_URL: " + url);
                log.LogInformation("IsSuccessStatusCode: " + results.IsSuccessStatusCode.ToString());

                if (!results.IsSuccessStatusCode)
                {
                    return new BadRequestObjectResult(new Response
                    {
                        Message = "No data Found"
                    });
                }

                countriesList = await ResponseProccessor.Get(results);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return countriesList;

        }




    }
}
