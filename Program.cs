namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            phoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).ToList();

            while (true)
            {
                var userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (!int.TryParse(userInput.ToString(), out int pageNumber) || pageNumber > 3 || pageNumber < 1) 
                {
                    Console.WriteLine("Input error");
                    continue;
                }

                var firstContact = phoneBook[pageNumber * 2 - 2];
                var secondContact = phoneBook[pageNumber * 2 - 1];
                Console.WriteLine($"Имя: {firstContact.Name}; Фамилия: {firstContact.LastName}; " +
                    $"Номер телефона: {firstContact.PhoneNumber}; Электронная почта: {firstContact.Email};");
                Console.WriteLine($"Имя: {secondContact.Name}; Фамилия: {secondContact.LastName}; " +
                    $"Номер телефона: {secondContact.PhoneNumber}; Электронная почта: {secondContact.Email};");
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}