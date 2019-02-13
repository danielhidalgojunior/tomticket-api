using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class StatusHistoryModel
    {
        [JsonProperty("status")]
        public string Stauts { get; set; }
        [JsonProperty("comentario")]
        public string Comment { get; set; }
        [JsonProperty("atendente_inicio")]
        public string StartStatusAttendant { get; set; }
        [JsonProperty("atendente_fim")]
        public string EndStatusAttendant { get; set; }
        [JsonProperty("inicio")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("fim")]
        public DateTime EndDate { get; set; }
    }
}
