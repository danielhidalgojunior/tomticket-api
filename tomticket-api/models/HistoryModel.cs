﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class HistoryModel
    {
        [JsonProperty("origem")]
        public string Source { get; set; }
        [JsonProperty("mensagem")]
        public string Message { get; set; }
        [JsonProperty("atendente")]
        public string Attendant { get; set; }
        [JsonProperty("data_hora")]
        public string Date { get; set; }
        [JsonProperty("hora_inicio")]
        public string StartMessageDate { get; set; }
        [JsonProperty("Hora_fim")]
        public string EndMessageDate { get; set; }
        [JsonProperty("anexos")]
        public IEnumerable<AttachmentModel> Attachments { get; set; }
    }
}
