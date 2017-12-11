
using example_app.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace example_app.Database.EF
{
    public class AppDbContext: DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
       public DbSet<User> Users { get; set; }
       public DbSet<Role> Roles { get; set; }
    }
}