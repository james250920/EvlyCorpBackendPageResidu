using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictsService _districtsService;
        public DistrictsController(IDistrictsService districtsService)
        {
            _districtsService = districtsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var districts = await _districtsService.GetAll();
            if(districts == null)
            {
                return NotFound();
            }
            return Ok(districts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var district = await _districtsService.GetById(id);
            if (district == null)
            {
                return NotFound();
            }
            return Ok(district);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DistrictsInsertDTO district)
        {
            var result = await _districtsService.Insert(district);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DistrictsUpdateDTO district)
        {
            var result = await _districtsService.Update(district);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _districtsService.Delete((new DistrictsDeleteDTO { Id = id }));
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
