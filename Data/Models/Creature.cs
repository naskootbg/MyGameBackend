namespace MyGame.Data.Models
{
    public class Creature
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
    }
}
