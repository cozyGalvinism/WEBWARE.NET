using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WEBWARE.NET.Responses
{
    public class COMRESULT
    {
        [JsonProperty("STATUS")]
        public int Status { get; set; }
        [JsonProperty("CODE")]
        public string Code { get; set; }
        [JsonProperty("INFO")]
        public string Info { get; set; }
        [JsonProperty("INFO2")]
        public string Info2 { get; set; }
        [JsonProperty("INFO3")]
        public string Info3 { get; set; }
        [JsonProperty("ERRNO")]
        public string ErrNo { get; set; }
    }
}
