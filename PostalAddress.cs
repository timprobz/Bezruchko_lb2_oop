using System;

namespace Lab02_AddressApp
{
    public class PostalAddress
    {
        // Статичний елемент класу: лічильник створених адрес
        public static int TotalAddresses { get; private set; } = 0;

        // Властивості для роздільної зміни складових частин адреси
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string PostalCode { get; set; }

        // 1. Конструктор за замовчуванням
        public PostalAddress()
        {
            Country = "Невідомо";
            City = "Невідомо";
            Street = "Невідомо";
            Building = "Невідомо";
            PostalCode = "00000";
            TotalAddresses++;
        }

        // 2. Конструктор з основними параметрами (без індексу)
        public PostalAddress(string country, string city, string street, string building)
        {
            Country = country;
            City = city;
            Street = street;
            Building = building;
            PostalCode = "00000";
            TotalAddresses++;
        }

        // 3. Конструктор з усіма параметрами
        public PostalAddress(string country, string city, string street, string building, string postalCode)
        {
            Country = country;
            City = city;
            Street = street;
            Building = building;
            PostalCode = postalCode;
            TotalAddresses++;
        }

        // Деструктор для демонстрації знищення об'єкта
        ~PostalAddress()
        {
            TotalAddresses--;
            // У C# збирач сміття (Garbage Collector) викликає деструктор автоматично,
            // коли об'єкт більше не використовується.
        }

        // Перевантаження методів: оновлення лише вулиці та будинку
        public void UpdateAddress(string street, string building)
        {
            Street = street;
            Building = building;
        }

        // Перевантаження методів: оновлення повної локації
        public void UpdateAddress(string city, string street, string building, string postalCode)
        {
            City = city;
            Street = street;
            Building = building;
            PostalCode = postalCode;
        }

        // Метод для форматованого виведення адреси
        public string GetFullAddress()
        {
            return $"{PostalCode}, {Country}, м. {City}, вул. {Street}, буд. {Building}";
        }
    }
}