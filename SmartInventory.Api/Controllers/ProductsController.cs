using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartInventory.Api.Data;
using SmartInventory.Api.Models;

namespace SmartInventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _db.Products
               .Include(p => p.Category)
               .Select(p => new { 
                    p.Id, p.Name, p.Price, p.Quantity, 
                    CategoryName = p.Category.Name 
                })
               .ToListAsync();
            return Ok(products);
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var totalProducts = await _db.Products.CountAsync();
            var totalCategories = await _db.Categories.CountAsync();
            var totalStockValue = await _db.Products.SumAsync(p => p.Price * p.Quantity);
            var lowStock = await _db.Products.CountAsync(p => p.Quantity < 50);
            
            return Ok(new { totalProducts, totalCategories, totalStockValue, lowStock });
        }
    }
}