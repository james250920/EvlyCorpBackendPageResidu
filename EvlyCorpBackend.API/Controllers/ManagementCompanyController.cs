using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagementCompanyController : ControllerBase
    {
        private readonly IManagementCompanyService _managementCompanyService;

        public ManagementCompanyController(IManagementCompanyService managementCompanyService)
        {
            _managementCompanyService = managementCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _managementCompanyService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _managementCompanyService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ManagementCompanyInsertDTO managementCompanyInsertDTO)
        {
            var result = await _managementCompanyService.Insert(managementCompanyInsertDTO);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ManagementCompanyUpdateDTO managementCompanyUpdateDTO)
        {
            if (id != managementCompanyUpdateDTO.Id)
            {
                return NotFound();
            }

            var result = await _managementCompanyService.Update(managementCompanyUpdateDTO);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managementCompanyService.Delete(new ManagementCompanyDeleteDTO { Id = id});
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }


    }
}
