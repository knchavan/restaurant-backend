using Microsoft.EntityFrameworkCore;
using restaurant_backend.Models;

namespace restaurant_backend.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}