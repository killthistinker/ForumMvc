using System.Threading.Tasks;
using ForumMvc.Models;

namespace ForumMvc.Services.Abstractions
{
    public interface IProfileService
    {
        public Task<User> GetUser(string name);
    }
}