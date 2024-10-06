using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.CORE.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiumsController : ControllerBase
    {
        private readonly ICondominiumsService _service;

        public CondominiumsController(ICondominiumsService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CondominiumsInsertDTO condominium)
        {
            var result = await _service.Insert(condominium);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CondominiumsDTO condominium)
        {
            var result = await _service.Update(condominium);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(CondominiumsDeleteDTO id)
        {
            var result = await _service.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
