using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtkinlikKatilimController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EtkinlikKatilimController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.EtkinlikKatilimlar.Include(e => e.Etkinlik).Include(e => e.Ogrenci).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var katilim = await _context.EtkinlikKatilimlar.Include(e => e.Etkinlik).Include(e => e.Ogrenci).FirstOrDefaultAsync(e => e.Id == id);
            if (katilim == null) return NotFound();
            return Ok(katilim);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EtkinlikKatilim katilim)
        {
            _context.EtkinlikKatilimlar.Add(katilim);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = katilim.Id }, katilim);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EtkinlikKatilim katilim)
        {
            if (id != katilim.Id) return BadRequest();
            _context.Entry(katilim).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var katilim = await _context.EtkinlikKatilimlar.FindAsync(id);
            if (katilim == null) return NotFound();
            _context.EtkinlikKatilimlar.Remove(katilim);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 