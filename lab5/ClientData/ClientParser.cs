// ClientParser.cs
using System;
using System.Collections.Generic;

namespace ClientLibrary
{
    public class ClientParser
    {
        // Метод для парсинга клиентов из строки
        public List<Client> ParseClients(string clientData)
        {
            var clients = new List<Client>();
            var lines = clientData.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                if (parts.Length == 4) // Ожидаем 4 части для клиента
                {
                    var client = new Client
                    {
                        FullName = parts[0].Trim(),
                        PhoneNumber = parts[1].Trim(),
                        Email = parts[2].Trim(),
                        Address = parts[3].Trim()
                    };

                    clients.Add(client);
                }
            }

            return clients;
        }
    }
}