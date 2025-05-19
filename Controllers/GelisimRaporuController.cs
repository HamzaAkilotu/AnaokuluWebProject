using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GelisimRaporuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GelisimRaporuController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.GelisimRaporlari.Include(g => g.Ogrenci).Include(g => g.Ogretmen).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rapor = await _context.GelisimRaporlari.Include(g => g.Ogrenci).Include(g => g.Ogretmen).FirstOrDefaultAsync(g => g.Id == id);
            if (rapor == null) return NotFound();
            return Ok(rapor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GelisimRaporu rapor)
        {
            _context.GelisimRaporlari.Add(rapor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = rapor.Id }, rapor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GelisimRaporu rapor)
        {
            if (id != rapor.Id) return BadRequest();
            _context.Entry(rapor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rapor = await _context.GelisimRaporlari.FindAsync(id);
            if (rapor == null) return NotFound();
            _context.GelisimRaporlari.Remove(rapor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 