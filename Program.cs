using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Mocks;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace GamesPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IGamesRepository, GameRepository>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sp => ShoppingCart.GetCart(sp));
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<ICasinoResultRepository, CasinoResultRepository>();
            builder.Services.AddTransient<IWalletRepository, WalletRepository>();
            builder.Services.AddTransient<IWithdrawRepository, WithdrawRepository>();
            builder.Services.AddTransient<IVerificationRepository, VerificationRepository>();
            builder.Services.AddMvc();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireAssertion(context =>
                        context.User.Identity.IsAuthenticated && context.User.Identity.Name == "admin@gamesino.com"));
            });

            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithReExecute("/Home/Error404", "?statusCode={0}");
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();
            StripeConfiguration.ApiKey = "sk_test_51MLfkELqDZptVo03ItEDQzIaHydvHEVvyIw7SV0Z0GmzqsDWyxV3lEWLkHzfnr4nrnxxInRobfod8LpmiLdlBqSw00oEP5ziP9";
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "gameDetails",
                pattern: "{controller=Games}/{action=Details}/{id?}");
            //app.MapControllerRoute(
                //name: "Library",
                //pattern: "{controller=Library}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}