using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SparkSwim.Core.Data;
using SparkSwim.Core.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var app = builder.Build();
Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddDbContext<UsersDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("UsersDbConnection"));
    });

    services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<UsersDbContext>()
        .AddDefaultTokenProviders();

    services.AddAuthorization();
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidIssuer = "SparkSwim.IdentityServer",

                ValidateAudience = true,
                ValidAudience = "Audience",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("365f100c-8f1e-4ff7-8c5c-c663c9a20f26"))
            };
        });
}

void Configure(IApplicationBuilder app)
{
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}