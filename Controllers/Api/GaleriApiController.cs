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
    public class GaleriApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GaleriApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Galeri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galeri>>> GetGaleri()
        {
            return await _context.Galeri
                .Where(g => g.AktifMi)
                .OrderByDescending(g => g.YuklemeTarihi)
                .Take(8)
                .ToListAsync();
        }

        // GET: api/Galeri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galeri>> GetGaleri(int id)
        {
            var galeri = await _context.Galeri.FindAsync(id);

            if (galeri == null)
            {
                return NotFound();
            }

            return galeri;
        }

        // POST: api/Galeri
        [HttpPost]
        public async Task<ActionResult<Galeri>> PostGaleri(Galeri galeri)
        {
            galeri.YuklemeTarihi = DateTime.Now;
            _context.Galeri.Add(galeri);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGaleri), new { id = galeri.Id }, galeri);
        }

        // PUT: api/Galeri/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGaleri(int id, Galeri galeri)
        {
            if (id != galeri.Id)
            {
                return BadRequest();
            }

            _context.Entry(galeri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GaleriExists(id))
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

        // DELETE: api/Galeri/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGaleri(int id)
        {
            var galeri = await _context.Galeri.FindAsync(id);
            if (galeri == null)
            {
                return NotFound();
            }

            _context.Galeri.Remove(galeri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GaleriExists(int id)
        {
            return _context.Galeri.Any(e => e.Id == id);
        }
    }
} 