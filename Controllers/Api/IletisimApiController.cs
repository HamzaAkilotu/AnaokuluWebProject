using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Models;
using AnaOkuluYS.Data;
using System.Threading.Tasks;

namespace AnaOkuluYS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimApiController : ControllerBase
    {
        private readonly IRepository<Iletisim> _iletisimRepository;

        public IletisimApiController(IRepository<Iletisim> iletisimRepository)
        {
            _iletisimRepository = iletisimRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var iletisimler = await _iletisimRepository.GetAllAsync();
            return Ok(iletisimler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var iletisim = await _iletisimRepository.GetByIdAsync(id);
            if (iletisim == null)
                return NotFound();
            return Ok(iletisim);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Iletisim iletisim)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iletisimRepository.AddAsync(iletisim);
            await _iletisimRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = iletisim.Id }, iletisim);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Iletisim iletisim)
        {
            if (id != iletisim.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iletisimRepository.UpdateAsync(iletisim);
            await _iletisimRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var iletisim = await _iletisimRepository.GetByIdAsync(id);
            if (iletisim == null)
                return NotFound();

            await _iletisimRepository.DeleteAsync(iletisim);
            await _iletisimRepository.SaveChangesAsync();
            return NoContent();
        }
    }
} 