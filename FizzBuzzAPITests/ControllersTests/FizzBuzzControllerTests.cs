using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FizzBuzzAPITests
{
    public class FizzBuzzControllerTests
    {
        private Mock<IFizzBuzzLogic> _fizzBuzzLogicInterface;
        private FizzBuzzModel _fizzBuzzModel;
        List<string> _listResult;
        private readonly string _testStringForControler = "Test string for Controller";

        [SetUp]
        public void Setup()
        {
            _fizzBuzzLogicInterface = new Mock<IFizzBuzzLogic>();
            _fizzBuzzModel = new FizzBuzzModel();
            _listResult = new List<string>();
        }

        [Test]
        [TestCase("This is a string")]
        public void ResolveFizzBuzz_GivenCorrectValue_ShouldReturnsOkResult(string value)
        {
            // Arrange
            _listResult.Add(_testStringForControler);
            _fizzBuzzLogicInterface.Setup(h => h.HandleFizzBuzzLogic(It.Is<FizzBuzzModel>(x => x.Value != null)))
                .Returns(() => _listResult);

            _fizzBuzzModel.Value = value;
            var controller = new FizzBuzzController(_fizzBuzzLogicInterface.Object);

            // Act
            var actionResult = controller.ResolveFizzBuzz(_fizzBuzzModel);
            var okObjectResult = actionResult as OkObjectResult;
            Assert.That(okObjectResult, Is.Not.Null);
            Assert.That(okObjectResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));

            List<string> result = okObjectResult.Value as List<string>;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(_listResult));
        }

        [Test]
        [TestCase(1)]
        [TestCase("1")]
        public void ResolveFizzBuzz_GivenWrongValue_ShouldReturnsNoContent(object value)
        {
            // Arrange
            _fizzBuzzLogicInterface.Setup(h => h.HandleFizzBuzzLogic(It.IsAny<FizzBuzzModel>()))
                .Returns(() => _listResult);

            _fizzBuzzModel.Value = value;
            var controller = new FizzBuzzController(_fizzBuzzLogicInterface.Object);

            // Act
            var actionResult = controller.ResolveFizzBuzz(_fizzBuzzModel);
            var result = actionResult as NoContentResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status204NoContent));
        }

        [Test]
        public void ResolveFizzBuzz_GivenCorrectValue_ShouldReturnsBadRequest()
        {
            // Arrange
            _fizzBuzzLogicInterface.Setup(h => h.HandleFizzBuzzLogic(It.IsAny<FizzBuzzModel>()))
                .Returns(() => null);
            var controller = new FizzBuzzController(_fizzBuzzLogicInterface.Object);

            // Act
            var actionResult = controller.ResolveFizzBuzz(null);
            var result = actionResult as BadRequestResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
        }
    }
}