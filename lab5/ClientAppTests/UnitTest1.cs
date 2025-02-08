using NUnit.Framework;
using ClientLibrary;

namespace ClientLibrary.Tests
{
    [TestFixture]
    public class ClientParserTests
    {
        [Test]
        public void ParseClients_MultipleClients_ReturnsCorrectClientData()
        {
            var parser = new ClientParser();
            string inputData = "Иванов Иван, 1234567890, ivanov@example.com, Москва\n" +
                               "Петров Петр, 0987654321, petrov@example.com, Санкт-Петербург\n" +
                               "Сидоров Сидор, 1122334455, sidorov@example.com, Новосибирск";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(3));
            Assert.That(clients[0].FullName, Is.EqualTo("Иванов Иван"));
            Assert.That(clients[1].FullName, Is.EqualTo("Петров Петр"));
            Assert.That(clients[2].FullName, Is.EqualTo("Сидоров Сидор"));
        }

        [Test]
        public void ParseClients_EmptyData_ReturnsEmptyList()
        {
            var parser = new ClientParser();
            string inputData = "";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(0));
        }

        [Test]
        public void ParseClients_SingleClient_ReturnsOneClient()
        {
            var parser = new ClientParser();
            string inputData = "Иванов Иван, 1234567890, ivanov@example.com, Москва";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(1));
            Assert.That(clients[0].FullName, Is.EqualTo("Иванов Иван"));
        }

        [Test]
        public void ParseClients_InvalidFormat_ReturnsEmptyList()
        {
            var parser = new ClientParser();
            string inputData = "Некорректные данные";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(0));
        }

        [Test]
        public void ParseClients_ExtraSpaces_ReturnsCorrectClientData()
        {
            var parser = new ClientParser();
            string inputData = " Иванов Иван ,  1234567890 ,   ivanov@example.com ,   Москва \n" +
                               " Петров Петр , 0987654321 , petrov@example.com , Санкт-Петербург ";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(2));
            Assert.That(clients[0].FullName, Is.EqualTo("Иванов Иван"));
            Assert.That(clients[1].FullName, Is.EqualTo("Петров Петр"));
        }

        [Test]
        public void ParseClients_EmptyLine_ReturnsCorrectClientData()
        {
            var parser = new ClientParser();
            string inputData = "Иванов Иван, 1234567890, ivanov@example.com, Москва\n\nПетров Петр, 0987654321, petrov@example.com, Санкт-Петербург";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(2));
            Assert.That(clients[0].FullName, Is.EqualTo("Иванов Иван"));
            Assert.That(clients[1].FullName, Is.EqualTo("Петров Петр"));
        }
    }
}