using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace do_an_ck
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebBanHangDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebBanHangDBContext") ?? throw new InvalidOperationException("Connection string 'WebBanHangDBContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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