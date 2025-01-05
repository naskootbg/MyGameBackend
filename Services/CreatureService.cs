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

        public async Task<IList<Creature>> All(int limit, int start)
        {
            if (limit == 0)
            {
                return await context.Creatures.Where(ch => ch.Id >= start)
                .ToListAsync();

            }
            else
            {
                return await context.Creatures.Where(ch => ch.Id >= start)
                .Take(limit).ToListAsync();
            }
            
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
