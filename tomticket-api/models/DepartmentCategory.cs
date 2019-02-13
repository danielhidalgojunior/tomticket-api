using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class DepartmentCategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
