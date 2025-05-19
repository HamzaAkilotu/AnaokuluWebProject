using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuyuruController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DuyuruController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Duyurular.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var duyuru = await _context.Duyurular.FindAsync(id);
            if (duyuru == null) return NotFound();
            return Ok(duyuru);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Duyuru duyuru)
        {
            _context.Duyurular.Add(duyuru);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = duyuru.Id }, duyuru);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Duyuru duyuru)
        {
            if (id != duyuru.Id) return BadRequest();
            _context.Entry(duyuru).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var duyuru = await _context.Duyurular.FindAsync(id);
            if (duyuru == null) return NotFound();
            _context.Duyurular.Remove(duyuru);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 