using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyGame.Data.Models;
using System.Reflection.Emit;

namespace MyGame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<SpecialSkill> SpecialSkills { get; set; }

        public DbSet<Creature> Creatures { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>().HasData(
           new Character
           {
               Id = 1,
               Name = "Blazefury",
               About = "A fiery warrior from the volcanic lands, wielding dual blazing swords.",
               Health = 1200,
               Armor = 150,
               Attack = 250,
               Image = "img/blazefury.png"
           },
           new Character
           {
               Id = 2,
               Name = "Frostbane",
               About = "An icy mage from the frozen north, mastering frost magic to subdue enemies.",
               Health = 800,
               Armor = 100,
               Attack = 300,
               Image = "img/icy.png"
           },
           new Character
           {
               Id = 3,
               Name = "Shadowblade",
               About = "A stealthy assassin who strikes from the shadows with precision and agility.",
               Health = 900,
               Armor = 80,
               Attack = 320,
               Image = "img/shadowblade.png"
           },
           new Character
           {
               Id = 4,
               Name = "Windrunner",
               About = "A swift archer blessed by the wind gods, firing arrows with unerring accuracy.",
               Health = 1000,
               Armor = 120,
               Attack = 240,
               Image = "img/windrunner.png"
           },
           new Character
           {
               Id = 5,
               Name = "Thunderfist",
               About = "A martial artist who channels the power of storms into electrifying punches.",
               Health = 1100,
               Armor = 100,
               Attack = 260,
               Image = "img/thunderfist.png"
           },
           new Character
           {
               Id = 6,
               Name = "Earthshaker",
               About = "A massive titan who wields the strength of the earth to crush his foes.",
               Health = 1400,
               Armor = 200,
               Attack = 200,
               Image = "img/earthshaker.png"
           },
           new Character
           {
               Id = 7,
               Name = "Celestia",
               About = "A radiant healer who channels divine energy to heal allies and smite foes.",
               Health = 900,
               Armor = 80,
               Attack = 220,
               Image = "img/celestia.png"
           },
           new Character
           {
               Id = 8,
               Name = "Venomstrike",
               About = "A toxic hunter who uses poison-tipped weapons to weaken and destroy enemies.",
               Health = 950,
               Armor = 90,
               Attack = 230,
               Image = "img/venomstrike.png"
           }
       );

            // Seed SpecialSkill Data
            modelBuilder.Entity<SpecialSkill>().HasData(
                // Blazefury's skills
                new SpecialSkill { Id = 1, Name = "Flame Slash", Attack = 300, Health = 0, CharacterId = 1 },
                new SpecialSkill { Id = 2, Name = "Molten Shield", Attack = 0, Health = 150, CharacterId = 1 },
                new SpecialSkill { Id = 3, Name = "Inferno Burst", Attack = 400, Health = -50, CharacterId = 1 },

                // Frostbane's skills
                new SpecialSkill { Id = 4, Name = "Frost Nova", Attack = 320, Health = 0, CharacterId = 2 },
                new SpecialSkill { Id = 5, Name = "Ice Barrier", Attack = 0, Health = 200, CharacterId = 2 },
                new SpecialSkill { Id = 6, Name = "Blizzard Storm", Attack = 350, Health = -30, CharacterId = 2 },

                // Shadowblade's skills
                new SpecialSkill { Id = 7, Name = "Shadow Strike", Attack = 400, Health = 0, CharacterId = 3 },
                new SpecialSkill { Id = 8, Name = "Smoke Bomb", Attack = 0, Health = 100, CharacterId = 3 },
                new SpecialSkill { Id = 9, Name = "Phantom Dash", Attack = 250, Health = -20, CharacterId = 3 },

                // Windrunner's skills
                new SpecialSkill { Id = 10, Name = "Piercing Shot", Attack = 280, Health = 0, CharacterId = 4 },
                new SpecialSkill { Id = 11, Name = "Wind Gust", Attack = 200, Health = 50, CharacterId = 4 },
                new SpecialSkill { Id = 12, Name = "Hurricane Volley", Attack = 350, Health = -40, CharacterId = 4 },

                // Thunderfist's skills
                new SpecialSkill { Id = 13, Name = "Lightning Strike", Attack = 350, Health = 0, CharacterId = 5 },
                new SpecialSkill { Id = 14, Name = "Storm Punch", Attack = 300, Health = 0, CharacterId = 5 },
                new SpecialSkill { Id = 15, Name = "Thunderclap", Attack = 250, Health = 80, CharacterId = 5 },

                // Earthshaker's skills
                new SpecialSkill { Id = 16, Name = "Seismic Slam", Attack = 250, Health = 100, CharacterId = 6 },
                new SpecialSkill { Id = 17, Name = "Earthquake", Attack = 300, Health = 50, CharacterId = 6 },
                new SpecialSkill { Id = 18, Name = "Stone Wall", Attack = 0, Health = 400, CharacterId = 6 },

                // Celestia's skills
                new SpecialSkill { Id = 19, Name = "Healing Light", Attack = 0, Health = 300, CharacterId = 7 },
                new SpecialSkill { Id = 20, Name = "Divine Shield", Attack = 0, Health = 400, CharacterId = 7 },
                new SpecialSkill { Id = 21, Name = "Holy Wrath", Attack = 350, Health = -50, CharacterId = 7 },

                // Venomstrike's skills
                new SpecialSkill { Id = 22, Name = "Poison Dart", Attack = 300, Health = 0, CharacterId = 8 },
                new SpecialSkill { Id = 23, Name = "Toxic Cloud", Attack = 250, Health = -20, CharacterId = 8 },
                new SpecialSkill { Id = 24, Name = "Venomous Bite", Attack = 350, Health = 50, CharacterId = 8 }
            );
            modelBuilder.Entity<Creature>().HasData(
               new Creature { Id = 1, Name = "Dark Warlock", Attack = 45, Defense = 30, Health = 180 },
               new Creature { Id = 2, Name = "Frost Revenant", Attack = 38, Defense = 35, Health = 210 },
               new Creature { Id = 3, Name = "Infernal Behemoth", Attack = 60, Defense = 25, Health = 320 },
               new Creature { Id = 4, Name = "Venomous Widow", Attack = 42, Defense = 20, Health = 150 },
               new Creature { Id = 5, Name = "Shadow Assassin", Attack = 50, Defense = 15, Health = 140 },
               new Creature { Id = 6, Name = "Cursed Wraith", Attack = 35, Defense = 10, Health = 100 },
               new Creature { Id = 7, Name = "Crimson Ogre", Attack = 48, Defense = 40, Health = 250 },
               new Creature { Id = 8, Name = "Bone Collector", Attack = 33, Defense = 25, Health = 170 },
               new Creature { Id = 9, Name = "Iron Golem", Attack = 20, Defense = 50, Health = 300 },
               new Creature { Id = 10, Name = "Plague Harbinger", Attack = 40, Defense = 30, Health = 200 },
               new Creature { Id = 11, Name = "Savage Werewolf", Attack = 55, Defense = 20, Health = 220 },
               new Creature { Id = 12, Name = "Void Stalker", Attack = 45, Defense = 35, Health = 210 },
               new Creature { Id = 13, Name = "Arcane Sentinel", Attack = 25, Defense = 50, Health = 250 },
               new Creature { Id = 14, Name = "Blazing Salamander", Attack = 42, Defense = 22, Health = 170 },
               new Creature { Id = 15, Name = "Soul Reaver", Attack = 50, Defense = 15, Health = 180 },
               new Creature { Id = 16, Name = "Nightmare Fiend", Attack = 48, Defense = 18, Health = 190 },
               new Creature { Id = 17, Name = "Titan Basilisk", Attack = 55, Defense = 30, Health = 280 },
               new Creature { Id = 18, Name = "Chaos Dragon", Attack = 70, Defense = 40, Health = 350 },
               new Creature { Id = 19, Name = "Ethereal Specter", Attack = 30, Defense = 20, Health = 120 },
               new Creature { Id = 20, Name = "Vampiric Duke", Attack = 60, Defense = 25, Health = 240 },
               new Creature { Id = 21, Name = "Gravebound Lich", Attack = 35, Defense = 25, Health = 190 },
               new Creature { Id = 22, Name = "Ashen Harpy", Attack = 40, Defense = 15, Health = 160 },
               new Creature { Id = 23, Name = "Rotting Colossus", Attack = 50, Defense = 40, Health = 290 },
               new Creature { Id = 24, Name = "Thunder Warden", Attack = 47, Defense = 28, Health = 220 },
               new Creature { Id = 25, Name = "Hellbound Minotaur", Attack = 58, Defense = 32, Health = 310 },
               new Creature { Id = 26, Name = "Twilight Chimera", Attack = 53, Defense = 27, Health = 260 },
               new Creature { Id = 27, Name = "Serpent Empress", Attack = 62, Defense = 30, Health = 300 },
               new Creature { Id = 28, Name = "Phantom Knight", Attack = 45, Defense = 35, Health = 200 },
               new Creature { Id = 29, Name = "Bloodthirster Fiend", Attack = 50, Defense = 15, Health = 190 },
               new Creature { Id = 30, Name = "Nether Beast", Attack = 40, Defense = 25, Health = 200 },
               new Creature { Id = 31, Name = "Frozen Colossus", Attack = 30, Defense = 55, Health = 330 },
               new Creature { Id = 32, Name = "Savage Centaur", Attack = 48, Defense = 25, Health = 210 },
               new Creature { Id = 33, Name = "Dread Scorpion", Attack = 45, Defense = 20, Health = 180 },
               new Creature { Id = 34, Name = "Blighted Treant", Attack = 38, Defense = 40, Health = 240 },
               new Creature { Id = 35, Name = "Infernal Colossus", Attack = 60, Defense = 28, Health = 320 },
               new Creature { Id = 36, Name = "Storm Djinn", Attack = 42, Defense = 35, Health = 230 },
               new Creature { Id = 37, Name = "Desert Manticore", Attack = 47, Defense = 22, Health = 210 },
               new Creature { Id = 38, Name = "Bone Wyvern", Attack = 55, Defense = 20, Health = 250 },
               new Creature { Id = 39, Name = "Venomfang Naga", Attack = 50, Defense = 18, Health = 190 },
               new Creature { Id = 40, Name = "Ravenous Gorgon", Attack = 52, Defense = 25, Health = 230 },
               new Creature { Id = 41, Name = "Void Leaper", Attack = 40, Defense = 30, Health = 180 },
               new Creature { Id = 42, Name = "Chaos Warlock", Attack = 65, Defense = 20, Health = 230 },
               new Creature { Id = 43, Name = "Glacial Yeti", Attack = 33, Defense = 45, Health = 290 },
               new Creature { Id = 44, Name = "Crystal Wyrm", Attack = 48, Defense = 30, Health = 240 },
               new Creature { Id = 45, Name = "Skeletal Sorcerer", Attack = 35, Defense = 18, Health = 150 },
               new Creature { Id = 46, Name = "Hellfire Demon", Attack = 68, Defense = 25, Health = 340 },
               new Creature { Id = 47, Name = "Forest Banshee", Attack = 30, Defense = 12, Health = 120 },
               new Creature { Id = 48, Name = "Titan Leviathan", Attack = 62, Defense = 40, Health = 360 },
               new Creature { Id = 49, Name = "Silverback Gorilla", Attack = 52, Defense = 25, Health = 220 },
               new Creature { Id = 50, Name = "Lava Behemoth", Attack = 70, Defense = 35, Health = 350 },
               new Creature { Id = 51, Name = "Soulshade Phantom", Attack = 40, Defense = 20, Health = 160 },
               new Creature { Id = 52, Name = "Feral Spirit", Attack = 38, Defense = 20, Health = 140 },
               new Creature { Id = 53, Name = "Corrupted Phoenix", Attack = 68, Defense = 32, Health = 320 }
       );
        }
    }
}
