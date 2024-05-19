using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
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

        public string? HandleFizzBuzzLogic(FizzBuzzModel obj)
        {
            object? value = GetObject(obj, nameof(FizzBuzzModel.Value));
            int result = ConvertToInt(value);

            if (IsFizzBuzz(result))
                return ReturnFizzBuzz();

            if (IsFizz(result))
                return ReturnFizz();

            if (IsBuzz(result))
                return ReturnBuzz();

            return null;
        }

        private int ConvertToInt(object? value) => Convert.ToInt32(value);

        private object? GetObject(object? obj, string name)
        {
            foreach (string part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj);
            }
            return obj;
        }
    }
}
