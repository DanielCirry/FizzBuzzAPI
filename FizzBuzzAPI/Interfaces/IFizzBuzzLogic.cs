namespace FizzBuzzAPI.Interfaces
{
    public interface IFizzBuzzLogic
    {
        bool IsFizz(int value);
        bool IsBuzz(int value);
        bool IsFizzBuzz(int value);
        string ReturnFizz(int value);
        string ReturnBuzz(int value);
        string ReturnFizzBuzz(int value);
        string ReturnNoValue(int value);
        string? HandleFizzBuzzLogic(object value);
    }
}
