using Microsoft.EntityFrameworkCore;
using SmartInventory.Api.Data;
using SmartInventory.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Auto migrate + seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.Categories.Any())
    {
        var electronics = new Category { Name = "Electronics" };
        var office = new Category { Name = "Office" };
        db.Categories.AddRange(electronics, office);

        db.Products.AddRange(
            new Product { Name = "Wireless Mouse", Description = "Ergonomic", Price = 12.50m, Quantity = 120, Category = electronics },
            new Product { Name = "Mechanical Keyboard", Description = "Blue switches", Price = 35.00m, Quantity = 50, Category = electronics },
            new Product { Name = "Notebook A4", Description = "100 pages", Price = 2.00m, Quantity = 500, Category = office }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();