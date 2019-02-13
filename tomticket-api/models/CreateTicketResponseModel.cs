using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tomticket_api.models
{
    public class CreateTicketResponseModel
    {
        [JsonProperty("erro")]
        public bool Error { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
