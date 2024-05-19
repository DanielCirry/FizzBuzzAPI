namespace FizzBuzzAPI.Interfaces
{
    public interface IFizzBuzzLogic
    {
        bool CheckIfItIsFizz(int value);
        bool CheckIfItIsBuzz(int value);
        bool CheckIftIsFizzBuzz(int value);
        string ReturnFizz(int value);
        string ReturnBuzz(int value);
        string ReturnFizzBuzz(int value);
        string ReturnNoValue(int value);
    }
}
