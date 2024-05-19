using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using FizzBuzzAPI.Services;
using Moq;
using Newtonsoft.Json.Linq;

namespace FizzBuzzAPITests
{
    public class FizzBuzzTests
    {
        private Mock<IFizzBuzzLogic> _fizzBuzzLogicInterface;
        private FizzBuzzModel _fizzBuzzModel;
        private string _fizz = "Fizz";
        private string _buzz = "Buzz";
        private string _fizzBuzz = "FizzBuzz";
        private string _testStringForControler = "Test string for Controller";

        [SetUp]
        public void Setup()
        {
            // 18:23 ->
            // Class with int Value
            // 1st method returns Fizz
            // 2nd method returns Buzz
            // 3rd method returns FizzBuzz
            // Check for return null
            // Check if type of Value is not a number
            // Do Reflections needs more testing other than "type"?
            // Am I going to mock the API or call the method?
            // <- 18:27

            // 18:37 ->
            // I am going to write the whole code in big chunks because I will eat soon with the whole family.
            // Also because my eyes hurts for some reasons, maybe i caught a cold, so I am not going to look at the screen continuosly.
            // writing initial generic tests
            // <- 18:38

            // 18:56 ->
            // got distracted by family

            _fizzBuzzModel = new FizzBuzzModel();
            _fizzBuzzLogicInterface = new Mock<IFizzBuzzLogic>();

            _fizzBuzzLogicInterface.Setup(h => h.HandleFizzBuzzLogic(It.IsAny<FizzBuzzModel>()))
                .Returns(() => _testStringForControler);

            _fizzBuzzLogicInterface.Setup(h => h.IsFizz(It.IsAny<int>()))
                .Returns<bool>(r => r = true);
            _fizzBuzzLogicInterface.Setup(h => h.ReturnFizz())
                .Returns(() => _fizz);

            _fizzBuzzLogicInterface.Setup(h => h.IsBuzz(It.IsAny<int>()))
                .Returns<bool>(r => r = true);
            _fizzBuzzLogicInterface.Setup(s => s.ReturnBuzz())
                .Returns(() => _buzz);

            _fizzBuzzLogicInterface.Setup(h => h.IsFizzBuzz(It.IsAny<int>()))
                .Returns<bool>(r => r = true);
            _fizzBuzzLogicInterface.Setup(s => s.ReturnFizzBuzz())
                .Returns(() => _fizzBuzz);

            // <- 18:57

            // 19:01 ->
            // I go and write the Interface now that I finished with the base tests
            // <- 19:07
            // I have wrote ReturnNoValue that is so useless because the other methods will return null, but I kind of have an idea.

            // my eyes hurts so much and there is pizza, I'll be back.
            // 20:26 ->
            // I am back. I don't need async, but my eye is not any better.
            // <- 20:39

            // 20:59 ->
            // family distracted me again, but they left now and my eye is hurting so much.
            // <- 21:01

            // -> 21:19
            // stopped for a bit because of eye
            // <- 21:38

            // -> 21:56
            // runs tests for the first time

            // -> 22:14
            // I am doing something wrong
            // -> 22:27
            // I don't need to mock the class, just the interface 

            // -> 22:49
            // I ned to create an object because I can't use "System.Int32" as the name of my property

            // -> 23:05 
            // GetProperty/ies keeps returning null

            // -> 23:12
            // my brain connected that i was still using an object and not my new Model
        }

        [Test]
        [TestCase("3")]
        public void ResolveFizzBuzz_GivenCorrectValue_ShouldReturnExpectedString(int value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;
            var controller = new FizzBuzzController(_fizzBuzzLogicInterface.Object);

            // Act
            string? result = controller.ResolveFizzBuzz(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("Test string for Controller"));
        }

        [Test]
        [TestCase("3")]
        public void HandleFizzBuzzLogic_GivenFizzValue_ShouldReturn_Fizz(int value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;
            var service = new FizzBuzzLogic();

            // Act
            string? result = service.HandleFizzBuzzLogic(_fizzBuzzModel);

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
            var service = new FizzBuzzLogic();

            // Act
            string? result = service.HandleFizzBuzzLogic(_fizzBuzzModel);

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
            var service = new FizzBuzzLogic();

            // Act
            string? result = service.HandleFizzBuzzLogic(_fizzBuzzModel);

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
            var service = new FizzBuzzLogic();

            // Act
            string? result = service.HandleFizzBuzzLogic(_fizzBuzzModel);

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
            var service = new FizzBuzzLogic();

            // Act
            string? result = service.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        [TestCase(0.001)] // Apparently decimals can't be used in TestCase
        public void HandleFizzBuzzLogic_GivenWrongValueType_ShouldReturn_Null(double value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;
            var service = new FizzBuzzLogic();

            // Act
            string? result = service.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNull(result);
        }
    }
}