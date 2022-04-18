using Newtonsoft.Json;
using palota_func_countries_assessment.Helpers;
using palota_func_countries_assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace palota_func_countries_assessment.Processor
{
    public static class ResponseProccessor
    {


        public static  List<CountryViewModel> BorderingCountries(List<CountryViewModel>countries,string code)
        {
            var list = new List<CountryViewModel>();

            var country = countries.FirstOrDefault(p => p.iso3Code == code);

            if (country != null && countries != null)
            {
                foreach (var item in countries.Where(P => P.subregion == country.subregion))
                {
                    if (item != country)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }


        public static async Task<List<CountryViewModel>> Get(HttpResponseMessage response)
        {
            var list=new List<CountryViewModel>();
            try
            {
                var mapper = Mappings.InitializeAutomapper();
                var jsonString = await response.Content.ReadAsStringAsync();
                list=mapper.Map<List<CountryViewModel>>(
                    JsonConvert.DeserializeObject<List<Country>>(jsonString));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }




    }
}
