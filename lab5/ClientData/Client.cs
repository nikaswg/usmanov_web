
namespace ClientLibrary
{
    public class Client
    {
        // Полное имя клиента
        public string FullName { get; set; }

        // Номер телефона клиента
        public string PhoneNumber { get; set; }

        // Адрес электронной почты клиента
        public string Email { get; set; }

        // Адрес клиента
        public string Address { get; set; }

        // Возвращает строковое представление клиента
        public override string ToString()
        {
            return $"{FullName}, {PhoneNumber}, {Email}, {Address}";
        }
    }
}