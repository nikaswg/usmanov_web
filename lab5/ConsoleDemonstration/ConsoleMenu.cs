// ConsoleMenu.cs
using System;

namespace ClientLibrary // Замените на ваше пространство имен
{
    public class ConsoleMenu
    {
        private readonly ClientParser _parser;
        private readonly ClientDataProvider _dataProvider;

        public ConsoleMenu()
        {
            _parser = new ClientParser();
            _dataProvider = new ClientDataProvider();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Меню ===");
                Console.WriteLine("1. Показать клиентов");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите опцию: ");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    DisplayClients();
                }
                else if (choice == "0")
                {
                    break; // Выход из цикла
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    Console.ReadKey();
                }
            }
        }

        private void DisplayClients()
        {
            var clientData = _dataProvider.GetClientData();
            var clients = _parser.ParseClients(clientData.ToString());

            Console.Clear();
            if (clients.Count == 0)
            {
                Console.WriteLine("Клиенты не найдены.");
            }
            else
            {
                Console.WriteLine($"Найдено клиентов: {clients.Count}");
                foreach (var client in clients)
                {
                    Console.WriteLine($"Клиент: {client}");
                }
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}