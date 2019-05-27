using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class ListCurrency
    {
        [JsonProperty("currencies")]
        public List<Currency> Currencies { get; set; }
    }
}
