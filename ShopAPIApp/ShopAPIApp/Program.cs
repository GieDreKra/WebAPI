using Microsoft.EntityFrameworkCore;
using ShopAPIApp.Data;
using ShopAPIApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var connectionString = "Server=T470S;Database=APIShops;Trusted_Connection=True;";
builder.Services.AddDbContext<DataContext>(c => c.UseSqlServer(connectionString));
builder.Services.AddDbContext<DataContext>(d => d.UseSqlServer(connectionString));
builder.Services.AddTransient<ShopService>();
builder.Services.AddTransient<ShopItemService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
