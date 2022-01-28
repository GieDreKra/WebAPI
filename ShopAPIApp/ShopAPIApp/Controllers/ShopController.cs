using Microsoft.AspNetCore.Mvc;
using ShopAPIApp.Dtos;
using ShopAPIApp.Exceptions;
using ShopAPIApp.Services;

namespace ShopAPIApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shopService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _shopService.GetByIdAsync(id));
            }
            catch (ShopNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShop createShop)
        {
            try
            {
                var createdId = await _shopService.CreateAsync(createShop);
                return Created("", createdId);
            }
            catch (ShopNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CreateShop createShop)
        {
            try
            {
                await _shopService.UpdateAsync(id, createShop);
                return NoContent();
            }
            catch (ShopNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shopService.DeleteAsync(id);
                return NoContent();
            }
            catch (ShopNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
