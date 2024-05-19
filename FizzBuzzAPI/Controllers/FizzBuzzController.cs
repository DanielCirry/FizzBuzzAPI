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

        [HttpGet]
        public string? ResolveFizzBuzz(FizzBuzzModel value)
        { 
            return _fizzBuzzLogic.HandleFizzBuzzLogic(value);
        }
    }
}
