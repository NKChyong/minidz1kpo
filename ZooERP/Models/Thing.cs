using ZooERP.Interfaces;

namespace ZooERP.Models
{
    public abstract class Thing : IInventory
    {
        public string Name { get; set; }
        public int Number { get; set; }

        protected Thing(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Name} (Инв. № {Number})";
        }
    }
}
