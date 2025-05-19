using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Data;
using AnaOkuluYS.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaOkuluYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Menuler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var menu = await _context.Menuler.FindAsync(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            _context.Menuler.Add(menu);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = menu.Id }, menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Menu menu)
        {
            if (id != menu.Id) return BadRequest();
            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var menu = await _context.Menuler.FindAsync(id);
            if (menu == null) return NotFound();
            _context.Menuler.Remove(menu);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 