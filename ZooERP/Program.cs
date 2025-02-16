using System;
using Microsoft.Extensions.DependencyInjection;
using ZooERP.Interfaces;
using ZooERP.Models;
using ZooERP.Services;

namespace ZooERP
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var zoo = serviceProvider.GetService<Zoo>();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить животное");
                Console.WriteLine("2. Вывести отчёт по животным (кол-во и кг еды)");
                Console.WriteLine("3. Показать животных для контактного зоопарка");
                Console.WriteLine("4. Вывести список инвентаризационных объектов");
                Console.WriteLine("5. Добавить инвентаризационный объект");
                Console.WriteLine("6. Выход");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAnimal(zoo);
                        break;
                    case "2":
                        ShowReport(zoo);
                        break;
                    case "3":
                        ShowContactZooAnimals(zoo);
                        break;
                    case "4":
                        zoo.ListInventoryItems();
                        break;
                    case "5":
                        AddInventoryItem(zoo);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.\n");
                        break;
                }
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
            services.AddSingleton<Zoo>();
        }

        private static void AddAnimal(Zoo zoo)
        {
            Console.WriteLine("\nВыберите тип животного для добавления:");
            Console.WriteLine("1. Обезьяна");
            Console.WriteLine("2. Кролик");
            Console.WriteLine("3. Тигр");
            Console.WriteLine("4. Волк");
            Console.Write("Ваш выбор: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Введите имя животного: ");
            string name = Console.ReadLine();
            Console.Write("Введите количество кг еды в сутки: ");
            int food = int.Parse(Console.ReadLine());
            Console.Write("Введите инвентаризационный номер: ");
            int number = int.Parse(Console.ReadLine());

            Animal animal = null;
            switch (typeChoice)
            {
                case "1":
                case "2":
                    Console.Write("Введите уровень доброты (от 0 до 10): ");
                    int kindness = int.Parse(Console.ReadLine());
                    if (typeChoice == "1")
                        animal = new Monkey(name, food, number, kindness);
                    else
                        animal = new Rabbit(name, food, number, kindness);
                    break;
                case "3":
                    animal = new Tiger(name, food, number);
                    break;
                case "4":
                    animal = new Wolf(name, food, number);
                    break;
                default:
                    Console.WriteLine("Неверный тип животного.\n");
                    return;
            }
            zoo.AddAnimal(animal);
        }

        private static void ShowReport(Zoo zoo)
        {
            Console.WriteLine($"\nОбщее количество животных: {zoo.Animals.Count}");
            Console.WriteLine($"Общее количество кг еды в сутки: {zoo.GetTotalFoodConsumption()}\n");
        }

        private static void ShowContactZooAnimals(Zoo zoo)
        {
            var contactAnimals = zoo.GetContactZooAnimals();
            if (contactAnimals.Count == 0)
            {
                Console.WriteLine("\nНет животных, подходящих для контактного зоопарка.\n");
            }
            else
            {
                Console.WriteLine("\nЖивотные, подходящие для контактного зоопарка:");
                foreach (var animal in contactAnimals)
                {
                    Console.WriteLine($"{animal.ToString()} | Уровень доброты: {animal.Kindness}");
                }
                Console.WriteLine();
            }
        }

        private static void AddInventoryItem(Zoo zoo)
        {
            Console.WriteLine("\nВыберите тип инвентаризационного объекта:");
            Console.WriteLine("1. Стол");
            Console.WriteLine("2. Компьютер");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            Console.Write("Введите название объекта: ");
            string name = Console.ReadLine();
            Console.Write("Введите инвентаризационный номер: ");
            int number = int.Parse(Console.ReadLine());

            Thing thing = null;
            switch (choice)
            {
                case "1":
                    thing = new Table(name, number);
                    break;
                case "2":
                    thing = new Computer(name, number);
                    break;
                default:
                    Console.WriteLine("Неверный выбор.\n");
                    return;
            }
            zoo.Things.Add(thing);
            Console.WriteLine($"Объект \"{thing.Name}\" успешно добавлен.\n");
        }
    }
}
