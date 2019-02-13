using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tomticket_api.models
{
    public class DepartmentResponseModel
    {
        [JsonProperty("erro")]
        public bool Error { get; set; }
        [JsonProperty("mensagem")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public IEnumerable<DepartmentModel> Departments { get; set; }

        public override string ToString()
        {
            return Message == null ? "Dados recebidos com sucesso." : Message;
        }
    }
}
