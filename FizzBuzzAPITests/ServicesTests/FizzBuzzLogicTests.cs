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
    public class FizzBuzzLogicTests
    {
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
            _fizzBuzzModel = new FizzBuzzModel();
        }

        [Test]
        [TestCase("3")]
        [TestCase(3)]
        [TestCase("21")]
        [TestCase(21)]
        [TestCase("63")]
        [TestCase(63)]
        public void HandleFizzBuzzLogic_GivenFizzValue_ShouldReturn_Fizz(object value)
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
        [TestCase(5)]
        [TestCase("35")]
        [TestCase(35)]
        [TestCase("50")]
        [TestCase(50)]
        public void HandleFizzBuzzLogic_GivenBuzzValue_ShouldReturn_Buzz(object value)
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
        [TestCase(15)]
        [TestCase("60")]
        [TestCase(60)]
        [TestCase("150")]
        [TestCase(150)]
        public void HandleFizzBuzzLogic_GivenFizzBuzzValue_ShouldReturn_FizzBuzzz(object value)
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
        [TestCase("50")]
        [TestCase(50)]
        [TestCase("63")]
        [TestCase(63)]
        [TestCase("150")]
        [TestCase(150)]
        public void HandleFizzBuzzLogic_GivenStringValueNumber_ShouldReturn_ExpectedResult(object value)
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
        public void HandleFizzBuzzLogic_GivenString_ShouldReturn_Null(object value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;

            // Act
            string? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        [TestCase("0.001")]
        [TestCase(0.001)] // Apparently decimals can't be used in TestCase
        public void HandleFizzBuzzLogic_GivenWrongValueType_ShouldReturn_Null(object value)
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