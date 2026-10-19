using E_Commerce_System_API_Final.Data;
using E_Commerce_System_API_Final.Models;
using E_Commerce_System_API_Final.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System_API_Final.Reposatories.Implmentation
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly AppDbContext _conetext;
        public UserRepo(AppDbContext context) : base(context)
        {
            _conetext = context;
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            var item = await _conetext.users.FirstOrDefaultAsync(n => n.FullName == userName);

            return item;
        }
    }
}
