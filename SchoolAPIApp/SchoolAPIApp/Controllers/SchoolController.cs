using Microsoft.AspNetCore.Mvc;
using SchoolAPIApp.Dtos;
using SchoolAPIApp.Exceptions;
using SchoolAPIApp.Services;

namespace SchoolAPIApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : Controller
    {

        private readonly SchoolService _schoolService;

        public SchoolController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _schoolService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSchool createSchool)
        {
            try
            {
                var createdId = await _schoolService.CreateAsync(createSchool);
                return Created("", createdId);
            }
            catch (SchoolNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _schoolService.DeleteAsync(id);
                return NoContent();
            }
            catch (SchoolNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
