using Microsoft.EntityFrameworkCore;
using twister.Server.Data;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using twister.Server.Interfaces;
using twister.Server.Repositories;

namespace twister.Server;
public class Program {
    public static void Main(string[] args){
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddDbContext<ApplicationDbContext>((options) => {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<IPostRepository, PostRepository>(); //adds post repository as a service for the app depdency inkection

        var app = builder.Build();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapFallbackToFile("/index.html");
        app.Run();
    }
}

