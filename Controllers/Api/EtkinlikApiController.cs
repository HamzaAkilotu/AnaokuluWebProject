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
    public class EtkinlikApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtkinlikApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Etkinlik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etkinlik>>> GetEtkinlikler()
        {
            return await _context.Etkinlikler
                .Where(e => e.Aktif && e.Tarih >= DateTime.Today)
                .OrderBy(e => e.Tarih)
                .Take(5)
                .ToListAsync();
        }

        // GET: api/Etkinlik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etkinlik>> GetEtkinlik(int id)
        {
            var etkinlik = await _context.Etkinlikler.FindAsync(id);

            if (etkinlik == null)
            {
                return NotFound();
            }

            return etkinlik;
        }

        // POST: api/Etkinlik
        [HttpPost]
        public async Task<ActionResult<Etkinlik>> PostEtkinlik(Etkinlik etkinlik)
        {
            _context.Etkinlikler.Add(etkinlik);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEtkinlik), new { id = etkinlik.Id }, etkinlik);
        }

        // PUT: api/Etkinlik/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtkinlik(int id, Etkinlik etkinlik)
        {
            if (id != etkinlik.Id)
            {
                return BadRequest();
            }

            _context.Entry(etkinlik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtkinlikExists(id))
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

        // DELETE: api/Etkinlik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtkinlik(int id)
        {
            var etkinlik = await _context.Etkinlikler.FindAsync(id);
            if (etkinlik == null)
            {
                return NotFound();
            }

            _context.Etkinlikler.Remove(etkinlik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtkinlikExists(int id)
        {
            return _context.Etkinlikler.Any(e => e.Id == id);
        }
    }
} 