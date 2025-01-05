using MyGame.Data.Models;
using MyGame.Models;

namespace MyGame.Contracts
{
    public interface ICreatureService
    {      
        Task<IList<Creature>> All(int limit, int start);
             
    }
}
