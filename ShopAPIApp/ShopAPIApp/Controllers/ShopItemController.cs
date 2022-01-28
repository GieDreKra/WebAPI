using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ShopAPIApp.Dtos;
using ShopAPIApp.Services;
using ShopAPIApp.Validators;

namespace ShopAPIApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopItemController : Controller
    {
        private readonly ShopItemService _shopItemService;

        public ShopItemController(ShopItemService shopItemService)
        {
            _shopItemService = shopItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shopItemService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return Ok(await _shopItemService.GetByIdAsync(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateShopItem createShopItem)
        {
            try
            {
                ShopItemValidator validator = new ShopItemValidator();
                ValidationResult result = validator.Validate(createShopItem);
                if (result.IsValid == false)
                {
                    return BadRequest(result);
                }
                var createdId = await _shopItemService.CreateAsync(createShopItem);
                return Created("", createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CreateShopItem createShopItem)
        {
            try
            {
                ShopItemValidator validator = new ShopItemValidator();
                validator.Validate(createShopItem, options => options.ThrowOnFailures());
                await _shopItemService.UpdateAsync(id, createShopItem);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shopItemService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
