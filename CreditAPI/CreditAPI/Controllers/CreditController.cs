using CreditAPI.Dtos;
using CreditAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditController : Controller
    {

        private readonly CreditService _creditService;

        public CreditController(CreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpPost]
        public  IActionResult GetCredit(Credit credit)
        {
            try
            {
                return Ok(_creditService.GetDecision(credit));
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

    }
}
