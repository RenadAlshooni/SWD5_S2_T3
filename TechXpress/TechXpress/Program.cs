using Microsoft.EntityFrameworkCore;
using TechXpress.Context;
using TechXpress_BLL.Contract;
using TechXpress_BLL.Implementation;
using TechXpress_DAL.Contract;
using TechXpress_DAL.Implementation;

namespace TechXpress
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=ALMOKABER\\SQLEXPRESS;Initial Catalog = TechXpress ;Integrated Security=True;Trust Server Certificate=True"));

            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IproductSevice, ProductService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
