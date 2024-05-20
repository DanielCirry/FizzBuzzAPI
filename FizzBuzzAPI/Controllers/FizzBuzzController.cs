using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzLogic _fizzBuzzLogic;

        public FizzBuzzController(IFizzBuzzLogic fizzBuzzLogic)
        {
            _fizzBuzzLogic = fizzBuzzLogic;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ResolveFizzBuzz(FizzBuzzModel model)
        {
            if (model == null)
                return BadRequest();

            var result = _fizzBuzzLogic.HandleFizzBuzzLogic(model);

            if (string.IsNullOrEmpty(result))
                return NoContent();

            return Ok(result);
        }
    }
}
