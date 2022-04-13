using Newtonsoft.Json;
using palota_func_countries_assessment.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace palota_func_countries_assessment.CountryRepository
{
    public static class CountryRepo
    {
        public static async Task<List<Country>> AllAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                   return JsonConvert.DeserializeObject<List<Country>>(jsonString);
                }
                else
                {
                    return null;
                }
            }
        }

        public static async Task<Country> GetByIsoCode(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Country>(jsonString);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
