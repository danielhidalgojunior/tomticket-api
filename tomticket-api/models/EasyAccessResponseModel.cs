using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class EasyAccessResponseModel
    {
        [JsonProperty("token_acesso")]
        public string TokenAccess { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
