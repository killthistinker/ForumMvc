using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace exam8.Models
{
    public class ForumContext : IdentityDbContext<User,Role,int>
    {
        
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
            
        }
    }
}