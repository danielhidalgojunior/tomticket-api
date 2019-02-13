using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class CustomFieldModel
    {
        [JsonProperty("id_campo")]
        public string CustomFieldId { get; set; }
        [JsonProperty("label")]
        public string CustomFieldLabel { get; set; }
        [JsonProperty("valor")]
        public string CustomFieldValue { get; set; }
    }
}
