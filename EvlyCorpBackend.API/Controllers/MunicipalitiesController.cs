using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly ImunicipalitiesService _municipalitiesService;
        public MunicipalitiesController(ImunicipalitiesService municipalitiesService)
        {
            _municipalitiesService = municipalitiesService;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] MunicipalitiesInsertDTO municipalitiesInsertDTO)
        {
            var result = await _municipalitiesService.Insert(municipalitiesInsertDTO);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MunicipalitiesUpdateDTO municipalitiesUpdateDTO)
        {
            if (id != municipalitiesUpdateDTO.Id)
            {
                return NotFound();
            }
            
            var result = await _municipalitiesService.Update(municipalitiesUpdateDTO);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _municipalitiesService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _municipalitiesService.GetAll();
            return Ok(result);
        }

    }
}
