using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.CORE.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvincesService _provincesService;
        public ProvincesController(IProvincesService provincesService)
        {
            _provincesService = provincesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _provincesService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _provincesService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProvincesInsertDTO provincesInsertDTO)
        {
            var result = await _provincesService.Insert(provincesInsertDTO);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProvincesUpdateDTO provincesUpdateDTO)
        {
            if (id != provincesUpdateDTO.Id)
            {
                return NotFound();
            }

            var result = await _provincesService.Update(provincesUpdateDTO);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _provincesService.Delete(new ProvincesDeleteDTO { Id = id });
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
