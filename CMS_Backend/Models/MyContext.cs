using Microsoft.EntityFrameworkCore;

namespace CMS_Backend.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public virtual DbSet<College> colleges { get; set; }
        public virtual DbSet<UserRoles> user_roles { get; set; }
        public virtual DbSet<User> users { get; set; }
    }
}
