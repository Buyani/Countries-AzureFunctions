using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace palota_func_countries_assessment.Models
{
    public class Response
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

