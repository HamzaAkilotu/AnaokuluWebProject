using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.BlogYazilari.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _context.BlogYazilari.FindAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            _context.BlogYazilari.Add(blog);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = blog.Id }, blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            if (id != blog.Id) return BadRequest();
            _context.Entry(blog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _context.BlogYazilari.FindAsync(id);
            if (blog == null) return NotFound();
            _context.BlogYazilari.Remove(blog);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 