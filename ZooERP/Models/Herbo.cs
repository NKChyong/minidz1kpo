namespace ZooERP.Models
{
    public abstract class Herbo : Animal
    {
        public int Kindness { get; set; }

        protected Herbo(string name, int food, int number, int kindness)
            : base(name, food, number)
        {
            Kindness = kindness;
        }
    }
}
