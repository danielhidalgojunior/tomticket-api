using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class ClientExistsResponseModel
    {
        [JsonProperty("erro")]
        public bool Error { get; set; }
        [JsonProperty("mensagem")]
        public string Message { get; set; }
        [JsonProperty("existe")]
        public bool Exists { get; set; }

        public override string ToString()
        {
            return Exists ? "Existe" : "Não existe";
        }
    }
}
