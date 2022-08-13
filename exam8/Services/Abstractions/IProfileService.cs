using System.Threading.Tasks;
using exam8.Models;

namespace exam8.Services.Abstractions
{
    public interface IProfileService
    {
        public Task<User> GetUser(string name);
    }
}