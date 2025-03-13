using Microsoft.EntityFrameworkCore;
using TechExpress.Models;

namespace TechExpress.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Product> products {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=TechExpress;Integrated Security=True;Trust Server Certificate=True; ");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }



    }
}
