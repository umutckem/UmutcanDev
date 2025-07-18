using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UmutcanDev.Application.Interfaces;
using UmutcanDev.Infrastructure.Data;
using UmutcanDev.Infrastructure.Services;

namespace UmutcanDev.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Connection string ve DbContext konfigürasyonu
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Geliþtirme ortamý için özel hata sayfalarý
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Identity konfigurasyonu
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // MVC ve Razor Pages
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Servisleri DI container'a ekle
            builder.Services.AddScoped<ISergiServices, SergiServices>();

            var app = builder.Build();

            // Ortam bazlý middleware ayarlarý
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();  // Authentication middleware eksik olabilir
            app.UseAuthorization();

            // Area route
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            // Default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
