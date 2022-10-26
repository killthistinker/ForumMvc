using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumMvc.Models
{
    public class ForumContext : IdentityDbContext<User,Role,int>
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
            
        }
    }
}