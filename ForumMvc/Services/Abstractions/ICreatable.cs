using System.Threading.Tasks;

namespace ForumMvc.Services.Abstractions
{
    public interface  ICreatable<in T> where T : class
    {
        public Task CreateAsync(T entity, string userName);
    }
}