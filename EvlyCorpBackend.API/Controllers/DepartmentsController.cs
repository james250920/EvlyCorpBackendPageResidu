using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;
        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentsService.GetAll();
            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentsService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(DepartmentsInsertDTO department)
        {
            var result = await _departmentsService.Insert(department);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
           
        }
        [HttpPut]
        public async Task<IActionResult> Update( [FromBody] DepartmentsUpdateDTO department)
        {
            
            var result = await _departmentsService.Update(department);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentsService.Delete(new DepartmentsDeleteDTO { Id = id });
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}

