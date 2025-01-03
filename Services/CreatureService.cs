using Microsoft.EntityFrameworkCore;
using MyGame.Contracts;
using MyGame.Data.Models;
using MyGame.Data;


namespace MyGame.Services
{
    public class CreatureService : ICreatureService
    {
        private readonly ApplicationDbContext context;
        

        public CreatureService(ApplicationDbContext _context)
        {
             context = _context;
             
        }

        public async Task<IList<Creature>> All()
        {
            return await context.Creatures.ToListAsync();
        }

        public IQueryable<Creature> AllCreatures()
        {
            var model =  context.Creatures.AsQueryable();
            return model;
            
        }

        public async Task<Creature> RandomCrature()
        {
            Random rnd = new Random();
            int enemyId = rnd.Next(0, 99);
            var result = await context.Creatures.AsNoTracking().Where(i => i.Id == enemyId).FirstOrDefaultAsync();
            return result!;
             

        }

    }
}
