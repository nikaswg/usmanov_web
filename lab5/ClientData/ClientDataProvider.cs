// ClientDataProvider.cs
using System.Text;

namespace ClientLibrary
{
    public class ClientDataProvider
    {
        // Метод для получения данных клиентов
        public StringBuilder GetClientData()
        {
            var clientData = new StringBuilder();
            clientData.AppendLine("Иванов Иван, 1234567890, ivanov@example.com, Москва");
            clientData.AppendLine("Петров Петр, 0987654321, petrov@example.com, Санкт-Петербург");
            clientData.AppendLine("Сидоров Сидор, 1122334455, sidorov@example.com, Новосибирск");
            return clientData;
        }
    }
}