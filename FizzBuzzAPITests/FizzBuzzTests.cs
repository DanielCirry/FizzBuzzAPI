using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using FizzBuzzAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FizzBuzzAPITests
{
    public class FizzBuzzTests
    {
        private Mock<IFizzBuzzLogic> _fizzBuzzLogicInterface;
        private FizzBuzzLogic _fizzBuzzLogic;
        private FizzBuzzModel _fizzBuzzModel;
        private string _fizz = "Fizz";
        private string _buzz = "Buzz";
        private string _fizzBuzz = "FizzBuzz";
        private string _testStringForControler = "Test string for Controller";

        [SetUp]
        public void Setup()
        {
            _fizzBuzzLogic = new FizzBuzzLogic();
            _fizzBuzzLogicInterface = new Mock<IFizzBuzzLogic>();
            _fizzBuzzModel = new FizzBuzzModel();

            _fizzBuzzLogicInterface.Setup(h => h.HandleFizzBuzzLogic(It.Is<FizzBuzzModel>(x => x.Value != null)))
                .Returns(() => _testStringForControler);
        }

        [Test]
        [TestCase("this is not null")]
        public void ResolveFizzBuzz_GivenCorrectValue_ShouldReturnsOkResult(string value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;
            var controller = new FizzBuzzController(_fizzBuzzLogicInterface.Object);

            // Act
            var actionResult = controller.ResolveFizzBuzz(_fizzBuzzModel);
            var okObjectResult = actionResult as OkObjectResult;
            Assert.That(okObjectResult, Is.Not.Null);
            Assert.That(okObjectResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));

            string? result = okObjectResult.Value as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("Test string for Controller"));
        }

        [Test]
        [TestCase("1")]
        public void ResolveFizzBuzz_GivenWrongValue_ShouldReturnsNoContent(string value)
        {
            // Arrange
            _fizzBuzzLogicInterface.Setup(h => h.HandleFizzBuzzLogic(It.IsAny<FizzBuzzModel>()))
                .Returns(() => string.Empty);

            _fizzBuzzModel.Value = value;
            var controller = new FizzBuzzController(_fizzBuzzLogicInterface.Object);

            // Act
            var actionResult = controller.ResolveFizzBuzz(_fizzBuzzModel);
            var result = actionResult as NoContentResult;

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status204NoContent));
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
            Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
        }

        [Test]
        [TestCase("3")]
        public void HandleFizzBuzzLogic_GivenFizzValue_ShouldReturn_Fizz(int value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;

            // Act
            string? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(_fizz));
        }

        [Test]
        [TestCase("5")]
        public void HandleFizzBuzzLogic_GivenBuzzValue_ShouldReturn_Buzz(int value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;

            // Act
            string? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(_buzz));
        }

        [Test]
        [TestCase("15")]
        public void HandleFizzBuzzLogic_GivenFizzBuzzValue_ShouldReturn_FizzBuzzz(int value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;

            // Act
            string? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(_fizzBuzz));
        }

        [Test]
        [TestCase("3")]
        [TestCase("5")]
        [TestCase("15")]
        public void HandleFizzBuzzLogic_GivenStringValueNumber_ShouldReturn_ExpectedResult(string value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;

            // Act
            string? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.AnyOf([_fizz, _buzz, _fizzBuzz]));
        }

        [Test]
        [TestCase("ABC")]
        public void HandleFizzBuzzLogic_GivenString_ShouldReturn_Null(string value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;

            // Act
            string? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        [TestCase(0.001)] // Apparently decimals can't be used in TestCase
        public void HandleFizzBuzzLogic_GivenWrongValueType_ShouldReturn_Null(double value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;

            // Act
            string? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}