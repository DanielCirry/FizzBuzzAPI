using Newtonsoft.Json;
using System.Reflection;

namespace FizzBuzzAPI.Helpers
{
    public class ObjectHelper
    {
        public static bool TryParseJson<T>(object? value, out T result)
        {
            bool success = true;
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };

            result = JsonConvert.DeserializeObject<T>(value.ToString(), settings);

            return success;
        }

        public static object? GetObject(object? obj, string name)
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
    }
}
