using System.Reflection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var app = builder.Build();

builder.Configuration.AddJsonFile("ocelotConfiguration.json", optional: false, reloadOnChange: true);

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddOcelot(builder.Configuration);
    services.AddControllers();
}

async void Configure(IApplicationBuilder app)
{
    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseCors("AllowAll");

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/", async context => { await context.Response.WriteAsync("API Gateway started"); });
    });
    await app.UseOcelot();
}