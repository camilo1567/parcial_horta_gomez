using Microsoft.EntityFrameworkCore;
using parcial_Horta_Gomez.Data;
using Microsoft.AspNetCore.Authorization;

namespace parcial_Horta_Gomez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "MyCookieAuth";
                options.DefaultChallengeScheme = "MyCookieAuth";
            })
            .AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCookieAuth";
                options.LoginPath = "/Auth/Login";
            });

            builder.Services.AddDbContext<RostrosFelicesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RostrosFelicesDB"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();

        }
    }
}