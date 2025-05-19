using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OgretmenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OgretmenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Ogretmenler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null) return NotFound();
            return Ok(ogretmen);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen ogretmen)
        {
            _context.Ogretmenler.Add(ogretmen);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ogretmen.Id }, ogretmen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ogretmen ogretmen)
        {
            if (id != ogretmen.Id) return BadRequest();
            _context.Entry(ogretmen).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null) return NotFound();
            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 