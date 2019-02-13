using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class ListClientsResponseModel
    {
        [JsonProperty("erro")]
        public bool Error { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public IEnumerable<ClientModel> Clients { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
