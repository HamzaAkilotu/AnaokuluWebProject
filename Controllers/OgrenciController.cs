using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OgrenciController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OgrenciController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Ogrenciler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null) return NotFound();
            return Ok(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci ogrenci)
        {
            _context.Ogrenciler.Add(ogrenci);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ogrenci.Id }, ogrenci);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ogrenci ogrenci)
        {
            if (id != ogrenci.Id) return BadRequest();
            _context.Entry(ogrenci).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null) return NotFound();
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 