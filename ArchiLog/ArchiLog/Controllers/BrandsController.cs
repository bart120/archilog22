using ArchiLog.Data;
using ArchiLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArchiLog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly ArchiLogDbContext _context;

        public BrandsController(ArchiLogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Brand>?> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        [HttpGet("{id}")]// /api/brands/3
        public async Task<ActionResult<Brand>> GetById([FromRoute]int id)
        {
           var item = await _context.Brands.SingleOrDefaultAsync(x => x.ID == id);
            if (item == null)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] Brand item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = item.ID }, item);
        }

    }
}
