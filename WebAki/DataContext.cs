using Microsoft.EntityFrameworkCore;
using WebAki.Enttines;

namespace WebAki
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        
        public DbSet<AppUser>? Users { get; set; }
    }
}