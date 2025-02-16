using System;
using System.Collections.Generic;
using ZooERP.Interfaces;
using ZooERP.Models;

namespace ZooERP.Services
{
    public class Zoo
    {
        private readonly IVeterinaryClinic _vetClinic;
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public List<Thing> Things { get; set; } = new List<Thing>();

        public Zoo(IVeterinaryClinic vetClinic)
        {
            _vetClinic = vetClinic;
        }

        public void AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckAnimal(animal))
            {
                Animals.Add(animal);
                Console.WriteLine($"Животное \"{animal.Name}\" успешно принято в зоопарк.\n");
            }
            else
            {
                Console.WriteLine($"Животное \"{animal.Name}\" не прошло медосмотр и не было принято.\n");
            }
        }

        public int GetTotalFoodConsumption()
        {
            int total = 0;
            foreach (var animal in Animals)
            {
                total += animal.Food;
            }
            return total;
        }

        public List<Herbo> GetContactZooAnimals()
        {
            var result = new List<Herbo>();
            foreach (var animal in Animals)
            {
                if (animal is Herbo herbo && herbo.Kindness > 5)
                {
                    result.Add(herbo);
                }
            }
            return result;
        }

        public void ListInventoryItems()
        {
            Console.WriteLine("\nИнвентаризационные объекты зоопарка:");
            foreach (var animal in Animals)
            {
                Console.WriteLine(animal.ToString());
            }
            foreach (var thing in Things)
            {
                Console.WriteLine(thing.ToString());
            }
            Console.WriteLine();
        }
    }
}
