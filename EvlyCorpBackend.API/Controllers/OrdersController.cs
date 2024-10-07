using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.CORE.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        
        [HttpPost("/orders")]
        public async Task<IActionResult> Insert(OrdersInsertDTO order)
        {
            var result = await _ordersService.Insert(order);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(OrdersUpdateDTO order)
        {
            var result = await _ordersService.Update(order);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ordersService.Delete(id);
            return Ok(result);
        }
        [HttpGet("/orders/condominiums/history")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ordersService.GetAll();
            return Ok(result);
        }
        [HttpGet("/orders/recyclers/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ordersService.GetById(id);
            return Ok(result);
        }



    }
}
