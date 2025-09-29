using Microsoft.EntityFrameworkCore;
using twister.Server.Data;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using twister.Server.Interfaces;
using twister.Server.Repositories;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
namespace twister.Server;
public class Program {
    public static void Main(string[] args){
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers()
            .AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options => {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
                Title = "twister API",
                Version = "v1"
            });
        });
        builder.Services.AddDbContext<ApplicationDbContext>((options) => {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlite(connectionString);
        });

        builder.Services.AddScoped<IPostRepository, PostRepository>(); //adds post repository as a service for the app depdency inkection
        builder.Services.AddScoped<ICommentRepository, CommentRepository>(); 

        var app = builder.Build();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI(options => {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "twister API v1");
            options.RoutePrefix = "swagger"; // served at /swagger
        });
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapRazorPages();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        app.Run();
    }
}

