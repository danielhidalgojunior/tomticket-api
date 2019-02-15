using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tomticket_api.models;

namespace tomticket_api
{
    public class EndPoint
    {
        public string ClientId { get; set; }
        private string Token { get; set; }

        public EndPoint(string _token, string _clientid = null)
        {
            Token = _token;
            ClientId = _clientid;
        }

        public string ClientEasyAccessEndPoint
        {
            get
            {
                if (ClientId == null) return null;
                return $"https://api.tomticket.com/criar_acesso_cliente/{Token}";
            }
        }

        public string ListDepartmentsEndPoint
        {
            get { return $"https://api.tomticket.com/departamentos/{Token}"; }
        }

        public string ListClientsEndPoint(int page = 1)
        {
            return $"https://api.tomticket.com/clientes/{Token}/{page}";
        }

        public string GetClientDetails(string identifier)
        {
            if (ClientId == null) return null;
            return $"https://api.tomticket.com/cliente/detalhes/{Token}/{ClientId}/{identifier}";
        }

        public string GetClientsExists
        {
            get
            {
                if (ClientId == null) return null;
                return $"https://api.tomticket.com/cliente/{Token}/{ClientId}";
            }
        }

        public string GetTicketDetailsEndPoint(string ticketid)
        {
            return $"https://api.tomticket.com/chamado/{Token}/{ticketid}";
        }

        public string GetTicketsEndPoint(int page = 1)
        {   
            return $"https://api.tomticket.com/chamados/{Token}/{page}";
        }

        public string CreateTicketEndPoint
        {
            get
            {
                if (ClientId == null) return null;
                return $"https://api.tomticket.com/criar_chamado/{Token}/{ClientId}";
            }
        }
    }
}
