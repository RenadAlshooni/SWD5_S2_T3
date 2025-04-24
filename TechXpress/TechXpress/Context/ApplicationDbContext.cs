using Microsoft.EntityFrameworkCore;

namespace TechXpress.Context
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
       
        }
    }
}
