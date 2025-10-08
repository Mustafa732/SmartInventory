using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartInventory.Api.Data;
using SmartInventory.Api.Models;

namespace SmartInventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Categories.ToListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _db.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }
    }
}