using FizzBuzzAPI.Interfaces;

namespace FizzBuzzAPI.Services
{
    public class FizzBuzzLogic : IFizzBuzzLogic
    {
        public bool CheckIfItIsFizz(int value)
        {
            return value % 3 == 0;
        }

        public bool CheckIfItIsBuzz(int value)
        {
            return value % 5 == 0;
        }

        public bool CheckIftIsFizzBuzz(int value)
        {
            return value % 15 == 0;
        }

        public string ReturnBuzz(int value)
        {
            throw new NotImplementedException();
        }

        public string ReturnFizz(int value)
        {
            throw new NotImplementedException();
        }

        public string ReturnFizzBuzz(int value)
        {
            throw new NotImplementedException();
        }

        public string ReturnNoValue(int value)
        {
            throw new NotImplementedException();
        }
    }
}
