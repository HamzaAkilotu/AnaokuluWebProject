using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnaOkuluYS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyuruApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DuyuruApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Duyuru
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duyuru>>> GetDuyurular()
        {
            return await _context.Duyurular
                .Where(d => d.Aktif)
                .OrderByDescending(d => d.YayinTarihi)
                .Take(5)
                .ToListAsync();
        }

        // GET: api/Duyuru/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Duyuru>> GetDuyuru(int id)
        {
            var duyuru = await _context.Duyurular.FindAsync(id);

            if (duyuru == null)
            {
                return NotFound();
            }

            return duyuru;
        }

        // POST: api/Duyuru
        [HttpPost]
        public async Task<ActionResult<Duyuru>> PostDuyuru(Duyuru duyuru)
        {
            duyuru.YayinTarihi = DateTime.Now;
            _context.Duyurular.Add(duyuru);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDuyuru), new { id = duyuru.Id }, duyuru);
        }

        // PUT: api/Duyuru/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuyuru(int id, Duyuru duyuru)
        {
            if (id != duyuru.Id)
            {
                return BadRequest();
            }

            _context.Entry(duyuru).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuyuruExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Duyuru/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuyuru(int id)
        {
            var duyuru = await _context.Duyurular.FindAsync(id);
            if (duyuru == null)
            {
                return NotFound();
            }

            _context.Duyurular.Remove(duyuru);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuyuruExists(int id)
        {
            return _context.Duyurular.Any(e => e.Id == id);
        }
    }
} 