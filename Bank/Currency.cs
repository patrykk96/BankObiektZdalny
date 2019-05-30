using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Currency
    {
        [JsonProperty("name")]
        public int Name { get; set; }
        [JsonProperty("target")]
        public int Target { get; set; }
        [JsonProperty("converter")]
        public double Converter { get; set; }
    }
}
