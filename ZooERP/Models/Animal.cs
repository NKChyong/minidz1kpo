using ZooERP.Interfaces;

namespace ZooERP.Models
{
    public abstract class Animal : IAlive, IInventory
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public int Number { get; set; }

        protected Animal(string name, int food, int number)
        {
            Name = name;
            Food = food;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Name} (Инв. № {Number})";
        }
    }
}
