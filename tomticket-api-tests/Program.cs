using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tomticket_api;
using tomticket_api.models;
using Colorfy;

namespace tomticket_api_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            xConsole.OpenChar = '<';
            xConsole.CloseChar = '>';

            new TomTicket("48bdb862b59308b7ef13b3f5ab3640b1");
            var token = TomTicket.Token;

            // Get Clients
            {
                var clients = ClientModel.GetClients();

                xConsole.WriteLine(
                    clients.Error ?
                    "<red>[Test fail] Can't get list of clients" :
                    $"<green>[Test success] Clients: {clients.Clients.Count()}"
                    );

                clients.Clients.ToList().ForEach(x => xConsole.WriteLine($"<white> * {x.Name}"));
                Console.WriteLine();
            }

            // Get a client by id
            {
                var client = ClientModel.GetClientById("cooperative");

                xConsole.WriteLine(
                    client.Error ?
                    "<red>[Test fail] Can't get client by ID" :
                    $"<green>[Test success] Client found: {client.Client.Name}"
                    );

                xConsole.WriteLine($"<white> * {client.Client.Name} / {client.Client.GetEasyAccessUrl()}");
                Console.WriteLine();
            }

            // Get a list of departments
            {
                var departments = DepartmentModel.GetDepartments();

                xConsole.WriteLine(
                    departments.Error ?
                    "<red>[Test fail] Can't get list of departments" :
                    $"<green>[Test success] Departments found: {departments.Departments.Count()}"
                    );

                departments.Departments.ToList().ForEach(x => xConsole.WriteLine($"<white> * {x.Name}"));
                Console.WriteLine();
            }

            // Get a list of categories in department
            {
                var categories = DepartmentModel.GetCategoriesByDepartmentName("Coopera");

                xConsole.WriteLine(
                    categories.Count() == 0 ?
                    "<red>[Test fail] Can't get list of categories in the department (Coopera)" :
                    $"<green>[Test success] Categories found: {categories.Count()}"
                    );

                categories.ToList().ForEach(x => xConsole.WriteLine($"<white> * {x.Name}"));
                Console.WriteLine();
            }

            // Get a list of tickets

            {
                var tickets = TicketModel.GetTickets().Tickets.ToList();

                xConsole.WriteLine(
                    tickets.Count() == 0 ?
                    "<red>[Test fail] Can't get list of tickets" :
                    $"<green>[Test success] Tickets found: {tickets.Count()}"
                    );

                tickets.ToList().ForEach(x => xConsole.WriteLine($"<white> * {x.Title} | {x.ClientName} | {x.TicketId}\n"));
                Console.WriteLine();
            }

            // Get a ticket by id

            {
                var ticket = TicketModel.GetTicketById("89f52377ff62367ead620da6d87e730a").Ticket;

                xConsole.WriteLine(
                    ticket == null ?
                    "<red>[Test fail] Can't get this ticket" :
                    $"<green>[Test success] ticket found: {ticket.TicketId}"
                    );

                xConsole.WriteLine($"<white> * {ticket.Title} | {ticket.ClientName} | {ticket.TicketId}\n");
                Console.WriteLine();
            }

            // Get messages of a ticket

            {
                var replies = TicketModel.GetTicketById("89f52377ff62367ead620da6d87e730a").Ticket.Replies;

                xConsole.WriteLine(
                    replies.Count() == 0 ?
                    "<red>[Test fail] Can't get list of replies in this ticket" :
                    $"<green>[Test success] replies found: {replies.Count()}"
                    );

                replies.ToList().ForEach(x => xConsole.WriteLine($"<white> * {x.Date} | {x.Message} | {x.Source}\n"));
                Console.WriteLine();
            }

            while (true) { }
        }
    }
}
