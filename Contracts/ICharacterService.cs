using MyGame.Data.Models;
using MyGame.Models;

namespace MyGame.Contracts
{
    public interface ICharacterService
    {
        Task<IList<CharacterViewModel>> All();
        Task<CharacterViewModel> Player(int id);

        Task<IList<SpecialSkill>> GetSkills(int charId);

        Task<int> AddChar(CharacterViewModel character);

        Task<CharacterViewModel> EditChar(int id, CharacterViewModel character);

    }
}
