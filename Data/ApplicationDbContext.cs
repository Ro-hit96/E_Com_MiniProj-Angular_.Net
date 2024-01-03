using E_ComMIniProj.Model;
using Microsoft.EntityFrameworkCore;

namespace E_ComMIniProj.Data
{
    // Defining the database context class
    public class ApplicationDbContext : DbContext
    {
        // Constructor that takes DbContextOptions as a parameter
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties representing tables in the database
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Register> registers { get; set; }
    }
}
