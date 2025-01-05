using Microsoft.EntityFrameworkCore;
using MyGame.Contracts;
using MyGame.Data;
using MyGame.Data.Models;
using MyGame.Models;

namespace MyGame.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext context;


        public CharacterService(ApplicationDbContext _context)
        {
            context = _context;
        }


        public async Task<int> AddChar(CharacterViewModel character)
        {
            var entity = new Character()
            {
                Armor = character.Armor,
                Name = character.Name,
                About = character.About,
                Attack = character.Attack,
                Health = character.Health,
                Image = character.Image,
                SpecialSkills = character.SpecialSkills.ToList()
            };
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IList<CharacterViewModel>> All()
        {
            return await context.Characters
                
                .Select(c => new CharacterViewModel
                {
                    Image = c.Image,
                    Id = c.Id,
                    About = c.About,
                    Armor = c.Armor,
                    Attack = c.Attack,
                    Health = c.Health,
                    Name = c.Name,
                    SpecialSkills = c.SpecialSkills


                })
                .ToListAsync();


        }

        public async Task<CharacterViewModel> EditChar(int id, CharacterViewModel? character)
        {
            var entity = await context.Characters.FindAsync(id);
            if (entity != null)
            {


                var skills = await GetSkills(id);
                if (character == null)
                {
                    var model = new CharacterViewModel()
                    {
                        Image = entity.Image,
                        Id = entity.Id,
                        About = entity.About,
                        Armor = entity.Armor,
                        Attack = entity.Attack,
                        Health = entity.Health,
                        Name = entity.Name,
                        SpecialSkills = entity.SpecialSkills
                    };
                    return model;
                }
                else
                {
                    entity.Image = character.Image;
                    entity.Id = character.Id;
                    entity.About = character.About;
                    entity.Armor = character.Armor;
                    entity.Attack = character.Attack;
                    entity.Health = character.Health;
                    entity.Name = character.Name;
                    entity.SpecialSkills = skills;
                    await context.SaveChangesAsync();

                    var model = new CharacterViewModel()
                    {
                        Image = character.Image,
                        Id = character.Id,
                        About = character.About,
                        Armor = character.Armor,
                        Attack = character.Attack,
                        Health = character.Health,
                        Name = character.Name,
                        SpecialSkills = character.SpecialSkills
                    };
                    return model;
                }
            }
            else { return new CharacterViewModel(); };
        }

        public async Task<IList<SpecialSkill>> GetSkills(int charId)
        {
            return await context.SpecialSkills
                .Where(c => c.Id == charId).ToListAsync();
        }

        public async Task<CharacterViewModel> Player(int id)
        {
            var character = await context.Characters.FindAsync(id);
             
            var model = new CharacterViewModel()
            {
                Image = character.Image,
                Id = character.Id,
                About = character.About,
                Armor = character.Armor,
                Attack = character.Attack,
                Health = character.Health,
                Name = character.Name,
                SpecialSkills = character.SpecialSkills
            };

            return model;
        }
    }
}
