using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_MiguelBetances.Components;
using Parcial1_AP1_MiguelBetances.Components.DAL;
using Parcial1_AP1_MiguelBetances.Service;

namespace Parcial1_AP1_MiguelBetances
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var ConStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContext<Context>(options => options.UseSqlite(ConStr));
            builder.Services.AddScoped<MetasService>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
