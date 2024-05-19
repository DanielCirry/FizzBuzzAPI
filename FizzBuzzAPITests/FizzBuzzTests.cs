using Moq;

namespace FizzBuzzAPITests
{
    public class FizzBuzzTests
    {
        private Mock<SomeService> _mock;
        private SomeResult _expectedResult;

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
            // Also because my eyes hurts for some reasons, maybe i caught a cold, so I am not going to look at the screen continuosly
            // writing initial generic tests
            // <- 18:38

            // 18:56 ->
            // got distracted by family

            _mock = new Mock<SomeService>();

            _expectedResult = new SomeResult();
            _mock.Setup(s => s.GetSomeResultAsync())
                .ReturnsAsync(_expectedResult); // Mock the async method

            // <- 18:57

            // 19:01 ->
            // I go and write the Interface
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