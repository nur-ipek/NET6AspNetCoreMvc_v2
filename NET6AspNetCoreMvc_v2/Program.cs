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
            //Profile class'ý implemente etmiþ class'larý bulacaðým. Yapýcý metotlarýný çalýþtýrýp map'lemeyi tetikleyeceðim.
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
                    //Burasý kullanýcýnýn rolünü kontrol eder. Login olup olmadýðýna bakmaz. Kullanýcý rolünün yetkisi yoksa kullanýcýyý /Home/AccessDenied'a gönderir.

                }
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // < pipeline
            //Bir istek geldiðinde neleri kontrol edeceðiz...
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