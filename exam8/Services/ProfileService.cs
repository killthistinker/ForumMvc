using System.Threading.Tasks;
using exam8.Models;
using exam8.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace exam8.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;

        public ProfileService(UserManager<User> userManager)
        {
           
            _userManager = userManager;
        }

        public async Task<User> GetUser(string name)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == name);
            if (user is null) return null;
            return user;
        }
    }
}