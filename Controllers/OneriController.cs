using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OneriController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OneriController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Oneriler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var oneri = await _context.Oneriler.FindAsync(id);
            if (oneri == null) return NotFound();
            return Ok(oneri);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Oneri oneri)
        {
            _context.Oneriler.Add(oneri);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = oneri.Id }, oneri);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Oneri oneri)
        {
            if (id != oneri.Id) return BadRequest();
            _context.Entry(oneri).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var oneri = await _context.Oneriler.FindAsync(id);
            if (oneri == null) return NotFound();
            _context.Oneriler.Remove(oneri);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 