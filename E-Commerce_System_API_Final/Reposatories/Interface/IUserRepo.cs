using E_Commerce_System_API_Final.Data;
using E_Commerce_System_API_Final.Models;

namespace E_Commerce_System_API_Final.Reposatories.Interface
{
    public interface IUserRepo : IGenericRepp<User>
    {
        Task<User> GetUserByUserName(string userName);
    }
}
