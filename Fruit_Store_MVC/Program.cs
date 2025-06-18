using Microsoft.AspNetCore.Identity;
using FruitStore.Fruit_Store.Infrastructure.Data;
using FruitStore.Infrastructure.Reposetory;
using Microsoft.EntityFrameworkCore;
using Fruit_Store.Core.Interfaces.Repository;
using Fruit_Store_MVC.Extention;


namespace FruitStore.Fruit_Store_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add Service DbContext.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // AddDefaultIdentity requires the correct namespace and package.
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            
                

            // Add Repository
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add Services
            builder.Services.AddApplactionServices();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=StaticPage}/{action=Index}/{id?}");

            app.Run();
        }
    }
}