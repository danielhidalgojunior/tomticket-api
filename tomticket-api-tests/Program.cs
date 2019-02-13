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
            }

            // Get a client by id
            {
                var client = ClientModel.GetClientById("cooperative");

                xConsole.WriteLine(
                    client.Error ?
                    "<red>[Test fail] Can't get client by ID" :
                    $"<green>[Test success] Client found: {client.Client.Name}"
                    );
            }

            // Get a list of departments
            {
                var departments = DepartmentModel.GetDepartments();

                xConsole.WriteLine(
                    departments.Error ?
                    "<red>[Test fail] Can't get list of departments" :
                    $"<green>[Test success] Departments found: {departments.Departments.Count()}"
                    );
            }

            // Get a list of categories in department
            {
                var categories = DepartmentModel.GetCategoriesByDepartmentName("Coopera");

                xConsole.WriteLine(
                    categories.Count() == 0 ?
                    "<red>[Test fail] Can't get list of categories in the department (Coopera)" :
                    $"<green>[Test success] Categories found: {categories.Count()}"
                    );
            }

            while (true) { }
        }
    }
}
