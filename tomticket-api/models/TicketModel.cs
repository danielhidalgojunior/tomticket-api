using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tomticket_api.models
{
    public class TicketModel
    {
        [JsonProperty("idchamado")]
        public string TicketId { get; set; }
        [JsonProperty("protocolo")]
        public string Protocol { get; set; }
        [JsonProperty("titulo")]
        public string Title { get; set; }
        [JsonProperty("mensagem")]
        public string Message { get; set; }
        [JsonProperty("nomecliente")]
        public string ClientName { get; set; }
        [JsonProperty("email_cliente")]
        public string ClientEmail { get; set; }
        [JsonProperty("id_cliente")]
        public string ClientId { get; set; }
        [JsonProperty("nomeorganizacao")]
        public string OrganizationName { get; set; }
        [JsonProperty("prioridade")]
        public int Priority { get; set; }
        [JsonProperty("tipochamado")]
        public string TicketType { get; set; }
        [JsonProperty("tempotrabalho")]
        public int WorkedTime { get; set; }
        [JsonProperty("tempoabertura")]
        public int OpeningTime { get; set; }
        [JsonProperty("data_criacao")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }
        [JsonProperty("valoritemhora")]
        public float HourValue { get; set; }
        [JsonProperty("valoritemhoraextra")]
        public float ExtraHourValue { get; set; }
        [JsonProperty("valorfinal")]
        public float FinalValue { get; set; }
        [JsonProperty("valorfinalextra")]
        public float ExtraFinalValue { get; set; }
        [JsonProperty("valorfinalbruto")]
        public float RawFinalVlaue { get; set; }
        [JsonProperty("avaliadoproblemaresolvido")]
        public string ProblemSolved { get; set; }
        [JsonProperty("avaliadoatendimento")]
        public string UserRating { get; set; }
        [JsonProperty("avaliacaocomentario")]
        public string Observation { get; set; }
        [JsonProperty("ultimasituacao")]
        public string LastSituationCode { get; set; }
        [JsonProperty("dataultimasituacao")]
        public DateTime LastSituationDate { get; set; }
        [JsonProperty("descsituacao")]
        public string LastSituationDescription { get; set; }
        [JsonProperty("categoria")]
        public string Category { get; set; }
        [JsonProperty("departamento")]
        public string Department { get; set; }
        [JsonProperty("atendente")]
        public string Attendant { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("dataultimostatus")]
        public DateTime StatusLastDate { get; set; }
        [JsonProperty("anexos")]
        public IEnumerable<AttachmentModel> Attachments { get; set; }
        [JsonProperty("historico")]
        public HistoryModel History { get; set; }
        [JsonProperty("campospersonalizados")]
        public CustomFieldModel CustomFieldsStart { get; set; }
        [JsonProperty("campospersonalizados_finalizados")]
        public CustomFieldModel CustomFieldsEnd { get; set; }
        [JsonProperty("historico_status")]
        public StatusHistoryModel StatusHistory { get; set; }

        public static TicketListResponseModel GetTickets(int page = 1)
        {
            var ep = new EndPoint(TomTicket.Token).GetTicketsEndPoint(page);
            var response = HttpHandler.GetResponse(ep);

            var obj = response.ToObject<TicketListResponseModel>();

            return obj;
        }

        public static TicketResponseModel GetTicketById(string ticketid)
        {
            var ep = new EndPoint(TomTicket.Token).GetTicketDetailsEndPoint(ticketid);
            var response = HttpHandler.GetResponse(ep);

            var obj = response.ToObject<TicketResponseModel>();

            return obj;
        }
    }
}
