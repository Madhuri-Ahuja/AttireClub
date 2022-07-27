using AttireClub.Models;
using Microsoft.EntityFrameworkCore;

namespace AttireClub.Data
{
    public class AttireClubDbContext : DbContext
    {
        public AttireClubDbContext(DbContextOptions<AttireClubDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
