using Microsoft.EntityFrameworkCore;
using EgetAspNetDatabasTest.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using EgetAspNetDatabasTest.Services;

namespace EgetAspNetDatabasTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
	            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/LoginRegister"; // Din inloggningssida
                    options.AccessDeniedPath = "/AccessDenied"; // Sida för "Åtkomst nekad"
                });

            builder.Services.AddScoped<IPostService, PostService>();

            var app = builder.Build();

            // Konfigurera HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Aktivera autentisering
            app.UseAuthorization(); // Aktivera auktorisering

            app.MapRazorPages();

            app.Run();
        }
    }
}
