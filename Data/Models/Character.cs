namespace MyGame.Data.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }
        public string Image { get; set; }
        public ICollection<SpecialSkill> SpecialSkills { get; set; }
    }
}
