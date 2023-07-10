using Microsoft.EntityFrameworkCore;
using SignalRApi.DataAccess;
using SignalRApi.Extensions;
using Microsoft.Extensions.Configuration;
using SignalRApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt=>
{
    opt.UseNpgsql("Server=localhost;Port=5432;Database=TraversalVisitorDb;User Id=postgres;Password=12345");
});
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
