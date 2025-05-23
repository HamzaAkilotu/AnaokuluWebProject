using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtkinlikController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EtkinlikController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Etkinlikler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var etkinlik = await _context.Etkinlikler.FirstOrDefaultAsync(e => e.Id == id);
            if (etkinlik == null) return NotFound();
            return Ok(etkinlik);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Etkinlik etkinlik)
        {
            _context.Etkinlikler.Add(etkinlik);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = etkinlik.Id }, etkinlik);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Etkinlik etkinlik)
        {
            if (id != etkinlik.Id) return BadRequest();
            _context.Entry(etkinlik).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var etkinlik = await _context.Etkinlikler.FindAsync(id);
            if (etkinlik == null) return NotFound();
            _context.Etkinlikler.Remove(etkinlik);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 