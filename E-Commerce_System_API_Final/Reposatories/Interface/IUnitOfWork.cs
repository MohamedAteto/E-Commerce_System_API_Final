using E_Commerce_System_API_Final.Models;

namespace E_Commerce_System_API_Final.Reposatories.Interface
{
    public interface IUnitOfWork
    {

        IUserRepo userRepo { get; }
        IGenericRepp<Category> CategoryRepo { get; }
        IProductRepo productRepo { get; }
        IOrderRepo orderRepo { get; }

        Task SaveChagnesAsync();
    }
}
