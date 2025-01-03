using Microsoft.EntityFrameworkCore;
using MyGame.Contracts;
using MyGame.Data;
using MyGame.Data.Models;

namespace MyGame.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext context;
         

        public CharacterService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Character> AllCharacters()
        {

            var model = context.Characters.AsQueryable();
            return model;
        }

        public IQueryable<SpecialSkill> GetSkills(int charId)
        {
            var model = context.SpecialSkills.Where(c=>c.CharacterId == charId).AsQueryable();
            return model;
        }
    }
}
