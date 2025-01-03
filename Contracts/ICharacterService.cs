using MyGame.Data.Models;

namespace MyGame.Contracts
{
    public interface ICharacterService
    {
        IQueryable<Character> AllCharacters();
        IQueryable<SpecialSkill> GetSkills(int charId);


    }
}
