using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NET6AspNetCoreMvc_v2.Entities;
using System.Reflection;

namespace NET6AspNetCoreMvc_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //Profile class'� implemente etmi� class'lar� bulaca��m. Yap�c� metotlar�n� �al��t�r�p map'lemeyi tetikleyece�im.
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddDbContext<DatabaseContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                //opts.UseLazyLoadingProxies();
            });

            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.Cookie.Name = ".NET6AspNetCoreMvc_v2.Auth";
                    opts.ExpireTimeSpan = TimeSpan.FromDays(7);
                    opts.SlidingExpiration = false;
                    opts.LoginPath = "/Account/Login";
                    opts.LogoutPath = "/Account/Logout";
                    opts.AccessDeniedPath = "/Home/AccessDenied";
                    //Buras� kullan�c�n�n rol�n� kontrol eder. Login olup olmad���na bakmaz. Kullan�c� rol�n�n yetkisi yoksa kullan�c�y� /Home/AccessDenied'a g�nderir.

                }
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // < pipeline
            //Bir istek geldi�inde neleri kontrol edece�iz...
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
            //  pipeline >

            app.Run();
        }
    }
}