using MyGame.Data.Models;

namespace MyGame.Contracts
{
    public interface ICreatureService
    {
        IQueryable<Creature> AllCreatures();       
        Task<IList<Creature>> All();
    }
}
