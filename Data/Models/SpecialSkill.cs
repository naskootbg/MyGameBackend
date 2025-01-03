namespace MyGame.Data.Models
{
    public class SpecialSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}