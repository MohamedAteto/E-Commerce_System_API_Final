using E_Commerce_System_API_Final.Data;
using E_Commerce_System_API_Final.Models;
using E_Commerce_System_API_Final.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System_API_Final.Reposatories.Implmentation
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetProductByName(string Name)
        {
            return await _context.products.Where(n => n.Name.Contains(Name)).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductsWithPagignationAndOptionalCategoryIDAndSortedByPrice(int? CategoryID, int pagenumber, int pagesize)
        {
            var items = await _context.products
                .Where(s => !CategoryID.HasValue || s.CategoryID == CategoryID)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .OrderByDescending(s => s.Price)
                .ToListAsync();

            return items;   
        }

        public async Task<ICollection<Product>> GetSecondMostExpensiveProductInACategory(int CategoryId)
        {
            var items = await _context.products
                 .Where(c => c.CategoryID == CategoryId)
                 .OrderByDescending(p => p.Price)
                 .Skip(1)
                 .Take(1).ToListAsync();

            return items;
        }

        public async Task<Product> PatchProductStockQuantity(int productid ,int Quantity)
        {
            var item = await _context.products.FindAsync(productid);

            item.StockQantity = Quantity;
            return item;
        }
    }
}
