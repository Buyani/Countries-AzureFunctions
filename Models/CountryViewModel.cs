using System;
using System.Collections.Generic;
using System.Text;

namespace palota_func_countries_assessment.Models
{
    public class CountryViewModel
    {
        public string name { get; set; }
        public string iso3Code { get; set; }
        public string subregion { get; set; }
        public string region { get; set; }
        public int population { get; set; }
        public string numericCode { get; set; }
        public string flag { get; set; }
        public string capital { get; set; }
        public string demonym { get; set; }
        public string nativeName { get; set; }
        public Location location { get; set; }
    }
}
