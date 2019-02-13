using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using tomticket_api.models;

namespace tomticket_api
{
    /*
     * O que essa biblioteca faz:
     * 
    @ * Listas Clientes
     * Responder um Chamado
     * Bloquear Criação de Chamados para Clientes
     * Verificar email na Blacklist
    @ * Detalhes do Cliente
     * Criacão de Origanizações
    @ * Verificar Existência de Clientes
    @ * Acesso Rápido para Clientes
     * Busca de Artigo na Base de Conhecimento
     * Criação de Clientes
    @ * Ler um Chamado
     * Listar Campos Personalizados
     * Atualizar Cliente
     * Ativar/Desativar Cliente
     * Listar Organizações
     * Limitar Consultas
    @ * Listar Chamados
    @ * Listagem de Departamentos
     * Iniciar Status em Chamado
     * Encerrar Status em Chamado
     * Inserir Comentário em Chamado
    @ * Criar um Chamado
     * 
     */

    public class TomTicket
    {
        public static string Token { get; set; }

        public TomTicket(string _token)
        {
            Token = _token;
        }        
    }
}
