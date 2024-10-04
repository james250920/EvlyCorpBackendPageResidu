using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WastesController : ControllerBase
    {
       private readonly IWastesService _wastesService;
        public WastesController(IWastesService wastesService)
        {
            _wastesService = wastesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _wastesService.GetAll();
            if(wastes == null)
            {
                return NotFound();
            }

            return Ok(wastes);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var wastes = await _wastesService.GetById(id);
            return Ok(wastes);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]  WastesInsertDTO wastesInsertDTO)
        {
            var result = await _wastesService.Insert(wastesInsertDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]  WastesUpdateDTO wastesUpdateDTO)
        {
            var result = await _wastesService.Update(wastesUpdateDTO);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _wastesService.Delete((new WastesDeleteDTO { Id = id }));
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
