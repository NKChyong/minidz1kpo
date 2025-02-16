using System;
using ZooERP.Models;
using ZooERP.Interfaces;

namespace ZooERP.Services
{
    public class VeterinaryClinic : IVeterinaryClinic
    {
        public bool CheckAnimal(Animal animal)
        {
            Console.WriteLine($"\nПроводится медосмотр животного \"{animal.Name}\".");
            Console.Write("Введите '1', если животное здорово, или '0', если нет: ");
            string input = Console.ReadLine();
            return input == "1";
        }
    }
}
