using FizzBuzzAPI.Models;
using FizzBuzzAPI.Services;

namespace FizzBuzzAPITests
{
    public class FizzBuzzLogicTests
    {
        private FizzBuzzLogic _fizzBuzzLogic;
        private FizzBuzzModel _fizzBuzzModel;
        List<string?> _listResult;
        private readonly string _fizz = "Fizz";
        private readonly string _buzz = "Buzz";
        private readonly string _fizzBuzz = "FizzBuzz";

        [SetUp]
        public void Setup()
        {
            _fizzBuzzLogic = new FizzBuzzLogic();
            _fizzBuzzModel = new FizzBuzzModel();
            _listResult = new List<string?>();
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
            _listResult.Add(_fizz);

            // Act
            List<string?>? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(_listResult));
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
            _listResult.Add(_buzz);

            // Act
            List<string?>? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(_listResult));
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
            _listResult.Add(_fizzBuzz);

            // Act
            List<string?>? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(_listResult));
        }

        [Test]
        [TestCase("[\"50\",50,\"63\",63,\"150\",150, \"ABC\"]")]
        public void HandleFizzBuzzLogic_GivenStringValueNumber_ShouldReturn_ExpectedResult(object value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;
            _listResult.Add(_buzz);
            _listResult.Add(_buzz);
            _listResult.Add(_fizz);
            _listResult.Add(_fizz);
            _listResult.Add(_fizzBuzz);
            _listResult.Add(_fizzBuzz);
            _listResult.Add("ABC");

            // Act
            List<string?>? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(_listResult));
        }

        [Test]
        [TestCase("ABC")]
        public void HandleFizzBuzzLogic_GivenString_ShouldReturn_OriginalValue(object value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;
            _listResult.Add("ABC");

            // Act
            List<string?>? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(_listResult));
        }

        [Test]
        [TestCase("0.001")]
        [TestCase(0.001)] // Apparently decimals can't be used in TestCase
        public void HandleFizzBuzzLogic_GivenWrongValueType_ShouldReturn_Null(object value)
        {
            // Arrange
            _fizzBuzzModel.Value = value;
            _listResult.Add("0.001");

            // Act
            List<string?>? result = _fizzBuzzLogic.HandleFizzBuzzLogic(_fizzBuzzModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(_listResult));
        }
    }
}