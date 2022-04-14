using Newtonsoft.Json;
using palota_func_countries_assessment.Helpers;
using palota_func_countries_assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace palota_func_countries_assessment.CountryRepository
{
    public static class CountryRepo
    {
        private static  async Task<List<Country>> Countries(string url)
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

        public static async Task<List<CountryViewModel>> Get(string url)
        {
            var mapper = Mappings.InitializeAutomapper();
            var list=new List<CountryViewModel>();

            var countries =await Countries(url);
            foreach (var country in countries)
            {
               list.Add(mapper.Map<CountryViewModel>(country));
            }

            return list;
        }

        public static async Task<List<CountryViewModel>> BorderingCountries(string url,string code)
        {
            var mapper = Mappings.InitializeAutomapper();
            var list = new List<CountryViewModel>();

            var countries = await Get(url);
            var single = countries.Find(p => p.iso3Code == code);

            if(single != null && countries != null)
            {
                foreach (var country in countries.Where(P=>P.subregion==single.subregion))
                {
                    list.Add(mapper.Map<CountryViewModel>(country));
                }
            }
            return list;
        }



    }
}
