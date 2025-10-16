using System;

namespace Lab3oop
{
    class Person
    {
        private string name;
        private int day;
        private int month;
        private int year;

        public Person(string name, int day, int month, int year)
        {
            this.name = name;
            this.day = day;
            this.month = month;
            this.year = year;
        }

        private int SumOfDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        public bool IsLuckyDay()
        {
            int daySum = SumOfDigits(day);
            int monthSum = SumOfDigits(month);
            int yearSum = SumOfDigits(year);

            int dayRemainder = daySum % 7;
            int monthRemainder = monthSum % 7;
            int yearRemainder = yearSum % 7;

            return (dayRemainder == monthRemainder) && (monthRemainder == yearRemainder);
        }

        public void Print()
        {
            Console.WriteLine($"Ім'я: {name}");
            Console.WriteLine($"Дата народження: {day:D2}.{month:D2}.{year}");
            Console.WriteLine($"Щасливий день: {(IsLuckyDay() ? "ТАК" : "НІ")}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введіть кількість людей: ");
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nЛюдина #{i + 1}:");
                Console.Write("Ім'я: ");
                string name = Console.ReadLine();
                Console.Write("День народження (1-31): ");
                int day = int.Parse(Console.ReadLine());
                Console.Write("Місяць народження (1-12): ");
                int month = int.Parse(Console.ReadLine());
                Console.Write("Рік народження: ");
                int year = int.Parse(Console.ReadLine());

                people[i] = new Person(name, day, month, year);
            }

            Console.WriteLine("\n=== Всі люди ===\n");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Людина #{i + 1}:");
                people[i].Print();
                Console.WriteLine();
            }

            // Визначення людей, які народилися в щасливі дні
            Console.WriteLine("=== Люди, народжені в щасливі дні ===\n");
            bool foundLucky = false;
            
            for (int i = 0; i < n; i++)
            {
                if (people[i].IsLuckyDay())
                {
                    Console.WriteLine($"Людина #{i + 1}:");
                    people[i].Print();
                    Console.WriteLine();
                    foundLucky = true;
                }
            }

            if (!foundLucky)
            {
                Console.WriteLine("Немає людей, які народилися в щасливі дні.");
            }
        }
    }
}
