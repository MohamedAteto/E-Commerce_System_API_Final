using E_Commerce_System_API_Final.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace E_Commerce_System_API_Final.Reposatories.Interface
{
    public interface IProductRepo : IGenericRepp<Product>
    {
        Task<ICollection<Product>> GetProductsWithPagignationAndOptionalCategoryIDAndSortedByPrice(int? CategoryID, int pagenumber, int pagesize);
        Task<ICollection<Product>> GetSecondMostExpensiveProductInACategory(int CategoryId);
        Task<Product> PatchProductStockQuantity(int productid,int Quantity);
        Task<ICollection<Product>> GetProductByName(string Name);
    }
}
