using E_Commerce_System_API_Final.Data;
using E_Commerce_System_API_Final.Models;
using E_Commerce_System_API_Final.Reposatories.Interface;

namespace E_Commerce_System_API_Final.Reposatories.Implmentation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepo userRepo { get; }
        private readonly AppDbContext _context;
        public IGenericRepp<Category> CategoryRepo { get; }
        public IProductRepo productRepo { get; }
        public IOrderRepo orderRepo { get; }

        public UnitOfWork(IUserRepo userRepo, AppDbContext context ,
            IGenericRepp<Category> categoryRepo, IProductRepo productRepo, IOrderRepo orderRepo)
        {
            this.userRepo = userRepo;
            _context = context;
            CategoryRepo = categoryRepo;
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
        }

        public async Task SaveChagnesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
