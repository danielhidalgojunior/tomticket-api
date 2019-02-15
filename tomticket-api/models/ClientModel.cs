using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class ClientModel
    {
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("telefone")]
        public string Telephone { get; set; }
        [JsonProperty("id_cliente")]
        public string ClientId { get; set; }
        [JsonProperty("cota_chamados")]
        public int TicketQuota { get; set; }
        [JsonProperty("criacao_chamado_bloqueada")]
        public bool CanCreateTicket { get; set; }
        [JsonProperty("nome_organizacao")]
        public string OrganizationName { get; set; }
        [JsonProperty("campospersonalizados")]
        public IEnumerable<CustomFieldModel> CustomFields { get; set; }

        public static ClientResponseModel GetClientById(string clientid)
        {
            var ep = new EndPoint(TomTicket.Token, clientid).GetClientDetails("I");
            var response = HttpHandler.GetResponse(ep);

            var obj = response.ToObject<ClientResponseModel>();

            return obj;
        }

        public static ClientExistsResponseModel ClientExists(string clientid)
        {
            var ep = new EndPoint(TomTicket.Token).GetClientsExists;
            var response = HttpHandler.GetResponse(ep);

            var obj = response.ToObject<ClientExistsResponseModel>();

            return obj;
        }

        public static ListClientsResponseModel GetClients(int page = 1)
        {
            var ep = new EndPoint(TomTicket.Token).ListClientsEndPoint(page);
            var response = HttpHandler.GetResponse(ep);

            var obj = response.ToObject<ListClientsResponseModel>();

            return obj;
        }

        public string GetEasyAccessUrl()
        {
            var content = HttpHandler.BuildMultiPartForm
                (
                    new MultipartFormItem(new StringContent(ClientId), "identificador"),
                    new MultipartFormItem(new StringContent("2"), "tipo_identificacao")
                );

            var json = HttpHandler.PostResponse(content, new EndPoint(TomTicket.Token, ClientId).ClientEasyAccessEndPoint);
            var obj = json.ToObject<EasyAccessResponseModel>();

            return obj.Url;
        }
    }
}
