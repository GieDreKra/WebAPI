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
        public IActionResult GetAll()
        {
            return Ok(_shopItemService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_shopItemService.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateShopItem createShopItem)
        {
            try
            {
                ShopItemValidator validator = new ShopItemValidator();
                ValidationResult result = validator.Validate(createShopItem);
                if (result.IsValid == false)
                {
                    return BadRequest(result);
                }
                var createdId = _shopItemService.Create(createShopItem);
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
        public IActionResult Update(int id, CreateShopItem createShopItem)
        {
            try
            {
                ShopItemValidator validator = new ShopItemValidator();
                validator.Validate(createShopItem, options => options.ThrowOnFailures());
                _shopItemService.Update(id, createShopItem);
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
        public IActionResult Delete(int id)
        {
            try
            {
                _shopItemService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
