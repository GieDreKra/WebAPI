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
        public IActionResult GetAll()
        {
            return Ok(_shopService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_shopService.GetById(id));
            }
            catch (ShopNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateShop createShop)
        {
            try
            {
                var createdId = _shopService.Create(createShop);
                return Created("", createdId);
            }
            catch (ShopNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateShop createShop)
        {
            try
            {
                _shopService.Update(id, createShop);
                return NoContent();
            }
            catch (ShopNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _shopService.Delete(id);
                return NoContent();
            }
            catch (ShopNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
