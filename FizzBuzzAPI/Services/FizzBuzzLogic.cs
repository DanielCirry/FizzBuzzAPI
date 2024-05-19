using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

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

        public string? HandleFizzBuzzLogic(FizzBuzzModel model)
        {
            try
            {
                if (model == null || model.Value == null)
                    return null;

                object? value = GetObject(model, nameof(FizzBuzzModel.Value));
                if (value == null)
                    return null;

                int result = ConvertToInt(value);

                if (result == 0)
                    return null;

                if (IsFizzBuzz(result))
                    return ReturnFizzBuzz();

                if (IsFizz(result))
                    return ReturnFizz();

                if (IsBuzz(result))
                    return ReturnBuzz();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }

        public object? GetObject(object? obj, string name)
        {
            foreach (string part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo? info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj);
            }
            return obj;
        }

        private int ConvertToInt(object value)
        {
            int.TryParse(value.ToString(), out int result);

            return result;
        }
    }
}
