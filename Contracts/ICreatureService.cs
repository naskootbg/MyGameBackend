using MyGame.Data.Models;

namespace MyGame.Contracts
{
    public interface ICreatureService
    {      
        Task<IList<Creature>> All();
    }
}
