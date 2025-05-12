using Elfie.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TechXpress.Context;
using TechXpress.Models;
<<<<<<< HEAD
using Stripe;
using TechXpress_BLL.Services.Contract;
using TechXpress_BLL.Services.Implementation;
using TechXpress_DAL.Repositories.Contract;
using TechXpress_DAL.Repositories.Implementation;
=======
using TechXpress_BLL.Contract;
using TechXpress_BLL.Implementation;
using TechXpress_DAL.Contract;
using TechXpress_DAL.Implementation;
using static System.Runtime.InteropServices.JavaScript.JSType;
>>>>>>> 8aa25825b967d5cab4322338d15d76da6c423eb8

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
            options.UseSqlServer("Data Source = ALMOKABER\\SQLEXPRESS;Initial Catalog = TechXpress2;Integrated Security = True; Encrypt = True; Trust Server Certificate = True"));
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
           // builder.Services.AddScoped<IproductSevice, ProductServices>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Stripe configuration
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
            builder.Services.AddScoped<IPaymentService, PaymentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
