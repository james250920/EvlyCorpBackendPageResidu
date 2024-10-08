﻿using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("[controller]")]
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
            return Ok(wastes);
        }

        [HttpGet("waste/:id{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var wastes = await _wastesService.GetById(id);
            if (wastes == null)
            {
                return NotFound();
            }
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
            return NoContent();
        }
        [HttpPut("waste/:id")]
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
        [HttpGet("wastes/export")]
        public async Task<IActionResult> ExportToCsv()
        {
            var stream = await _wastesService.ExportToCsv();
            var fileName = $"Wastes_{DateTime.Now:yyyyMMddHHmmss}.csv"; // Nombre del archivo
            return File(stream, "text/csv", fileName); // Retornar el archivo CSV
        }
    }
}
