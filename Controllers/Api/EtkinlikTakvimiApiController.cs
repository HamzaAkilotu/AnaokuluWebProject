using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Models;
using AnaOkuluYS.Data;
using System.Threading.Tasks;

namespace AnaOkuluYS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtkinlikTakvimiApiController : ControllerBase
    {
        private readonly IRepository<EtkinlikTakvimi> _etkinlikRepository;

        public EtkinlikTakvimiApiController(IRepository<EtkinlikTakvimi> etkinlikRepository)
        {
            _etkinlikRepository = etkinlikRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var etkinlikler = await _etkinlikRepository.GetAllAsync();
            return Ok(etkinlikler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var etkinlik = await _etkinlikRepository.GetByIdAsync(id);
            if (etkinlik == null)
                return NotFound();
            return Ok(etkinlik);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EtkinlikTakvimi etkinlik)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _etkinlikRepository.AddAsync(etkinlik);
            await _etkinlikRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = etkinlik.Id }, etkinlik);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EtkinlikTakvimi etkinlik)
        {
            if (id != etkinlik.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _etkinlikRepository.UpdateAsync(etkinlik);
            await _etkinlikRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var etkinlik = await _etkinlikRepository.GetByIdAsync(id);
            if (etkinlik == null)
                return NotFound();

            await _etkinlikRepository.DeleteAsync(etkinlik);
            await _etkinlikRepository.SaveChangesAsync();
            return NoContent();
        }
    }
} 