using E_Commerce_System_API_Final.Data;
using E_Commerce_System_API_Final.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System_API_Final.Reposatories.Implmentation
{
    public class GenericRepo<T> : IGenericRepp<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> set;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            set =  _context.Set<T>();
        }

        public async Task Create(T Entity)
        {
            await set.AddAsync(Entity);
        }

        public async Task Delete(int id)
        {
            var item = await set.FindAsync(id);
            set.Remove(item);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await set.ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            var item = await set.FindAsync(id);
            return item;
        }

        public async Task Update(int id, T Entity)
        {
            var item =await set.FindAsync(id);

             set.Entry(item).CurrentValues.SetValues(Entity);
        }
    }
}
