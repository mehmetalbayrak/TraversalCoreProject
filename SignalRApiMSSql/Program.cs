using Microsoft.EntityFrameworkCore;
using SignalRApiMSSql.DataAccess;
using SignalRApiMSSql.Hubs;
using SignalRApiMSSql.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer("server=LAPTOP-JDE28UMP;database=TraversalVisitorDb;integrated security=true;");
});

builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<VisitorHub>("/VisitorHub");
});

app.MapControllers();

app.Run();
