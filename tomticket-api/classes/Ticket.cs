using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using tomticket_api.models;

namespace tomticket_api
{
    public class Ticket
    {
        public CreateTicketResponseModel CreateTicket(string departmentid, string typeid, string title, string message)
        {
            string endpointfull = new EndPoint(TomTicket.Token).CreateTicketEndPoint;
            var content = HttpHandler.BuildMultiPartForm
                (
                    new MultipartFormItem(new StringContent(departmentid), "id_departamento"),
                    new MultipartFormItem(new StringContent(title), "titulo"),
                    new MultipartFormItem(new StringContent(message), "mensagem"),
                    new MultipartFormItem(new StringContent(typeid), "id_tipoassunto"),
                    new MultipartFormItem(new StringContent("I"), "tipo_identificador"),
                    new MultipartFormItem(new StringContent("2"), "prioridade")
                );

            var response = HttpHandler.PostResponse(content, endpointfull);

            var obj = response.ToObject<CreateTicketResponseModel>();

            return obj;
        }
    }
}
