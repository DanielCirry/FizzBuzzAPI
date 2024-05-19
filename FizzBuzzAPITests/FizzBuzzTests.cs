using FizzBuzzAPI.Services;
using Moq;

namespace FizzBuzzAPITests
{
    public class FizzBuzzTests
    {
        private Mock<FizzBuzzLogic> _mock;
        private string _fizz;
        private string _buzz;
        private string _fizzBuzz;

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

            _mock = new Mock<FizzBuzzLogic>();

            _mock.Setup(h => h.ReturnFizz(It.IsAny<int>()))
                .Callback<string>(r => _fizz = r);
            
            _mock.Setup(s => s.ReturnBuzz(It.IsAny<int>()))
                .Callback<string>(r => _buzz = r);

            _mock.Setup(s => s.ReturnFizzBuzz(It.IsAny<int>()))
                .Callback<string>(r => _fizzBuzz = r);

            // <- 18:57

            // 19:01 ->
            // I go and write the Interface now that I finished with the base tests
            // <- 19:07
            // I have wrote ReturnNoValue that is so useless because the other methods will return null, but I kind of have an idea.

            // my eyes hurts so much and there is pizza, I'll be back.
        }

        [Test]
        public void GivesCorrectValue_ShouldReturn_Fizz()
        {
            int value = 3;

            string result = classs.CallTheApiMethodHere(value);
            Assert.Pass();
        }

        [Test]
        public void GivesCorrectValue_ShouldReturn_Buzz()
        {
            int value = 3;

            string result = classs.CallTheApiMethodHere(value);
            Assert.Pass();
        }

        [Test]
        public void GivesCorrectValue_ShouldReturn_FizzBuzzz()
        {
            int value = 3;

            string result = classs.CallTheApiMethodHere(value);
            Assert.Pass();
        }

        [Test]
        public void GivesWrongValue_ShouldReturn_Null()
        {
            int value = 3;

            string result = classs.CallTheApiMethodHere(value);
            Assert.Pass();
        }

        [Test]
        [TestCase("3")]
        [TestCase("5")]
        [TestCase("15")]
        public void GivesStringValueTypeNumber_ShouldReturn_ExpectedResult(string value)
        {
            var result = classs.CallTheApiMethodHere(value);
            Assert.IsNotNull(result);
            Assert.That(result, Is.AnyOf(["Fizzz", "Buzzz", "FizzBuzz"]));
            Assert.IsNotNull(result);
        }

        [Test]
        public void GivesWrongValueType_ShouldReturn_Null()
        {
            string value = "abc";

            string result = classs.CallTheApiMethodHere(value);
            Assert.Null(result);
        }
    }
}