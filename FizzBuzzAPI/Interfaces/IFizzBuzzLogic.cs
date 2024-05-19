namespace FizzBuzzAPI.Interfaces
{
    public interface IFizzBuzzLogic
    {
        Task<bool> CheckIfIsFizz(int value);
        Task<bool> CheckIfIsBuzzz(int value);
        Task<bool> CheckIfIsFizzBuzz(int value);
        Task<string> ReturnFizz(int value);
        Task<string> ReturnBuzz(int value);
        Task<string> ReturnFizzBuzz(int value);
        Task<string> ReturnNoValue(int value);
    }
}
