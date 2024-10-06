using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.CORE.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiumWastesController : ControllerBase
    {
        private readonly ICondominiumWastesService _condominiumWastesService;

        public CondominiumWastesController(ICondominiumWastesService condominiumWastesService)
        {
            _condominiumWastesService = condominiumWastesService;
        }


        [HttpPost]
        public async Task<IActionResult> Insert(CondominiumWastesInsertDTO condominiumWastesInsertDTO)
        {
            var result = await _condominiumWastesService.Insert(condominiumWastesInsertDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CondominiumWastesUpdateDTO condominiumWastesUpdateDTO)
        {
            var result = await _condominiumWastesService.Update(condominiumWastesUpdateDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _condominiumWastesService.Delete(id);
            return Ok(result);
        }
        [HttpGet("/condominium/wastes")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _condominiumWastesService.GetAll();
            return Ok(result);
        }
        [HttpGet("/condominium/wastes/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _condominiumWastesService.GetById(id);
            return Ok(result);
        }

    }
}
