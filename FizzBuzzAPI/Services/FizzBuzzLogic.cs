using FizzBuzzAPI.Helpers;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;

namespace FizzBuzzAPI.Services
{
    public class FizzBuzzLogic : IFizzBuzzLogic
    {
        public bool IsFizz(int value) => value % 3 == 0;

        public bool IsBuzz(int value) => value % 5 == 0;

        public bool IsFizzBuzz(int value) => value % 15 == 0;

        public string ReturnBuzz() => "Buzz";

        public string ReturnFizz() => "Fizz";

        public string ReturnFizzBuzz() => "FizzBuzz";

        public List<string?>? HandleFizzBuzzLogic(FizzBuzzModel model)
        {
            try
            {
                if (model == null || model.Value == null)
                    return null;

                object? value = ObjectHelper.GetObject(model, nameof(FizzBuzzModel.Value));
                if (value == null)
                    return null;

                List<string?> listResult = new List<string?>();

                if (!ObjectHelper.TryParseJson(value, out List<string> listOfValues))
                    listResult.Add(HandleFizzBuzz(value));


                if (listOfValues != null)
                    foreach (var item in listOfValues)
                    {
                        listResult.Add(HandleFizzBuzz(item));
                    }

                return listResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }

        private string? HandleFizzBuzz(object? value)
        {
            int result = ConvertToInt(value);

            if (result == 0)
                return value?.ToString();

            if (IsFizzBuzz(result))
                return ReturnFizzBuzz();

            if (IsFizz(result))
                return ReturnFizz();

            if (IsBuzz(result))
                return ReturnBuzz();

            return value?.ToString();
        }

        private int ConvertToInt(object? value)
        {
            int.TryParse(value?.ToString(), out int result);

            return result;
        }
    }
}
