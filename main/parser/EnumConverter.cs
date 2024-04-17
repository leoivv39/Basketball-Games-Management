using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace main.parser
{
    public class EnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumStr = reader.GetString()!;
            enumStr = IsUppercasedSnakeCase(enumStr) ? ConvertFromSnakeCase(enumStr) : enumStr;
            Enum.TryParse(enumStr, out T enumResult);
            return enumResult;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(ConvertToSnakeCase(value.ToString()));
        }

        private string ConvertToSnakeCase(string input)
        {
            string[] parts = Regex.Split(input, @"(?<!^)(?=[A-Z])");
            string result = string.Join("_", parts).ToUpper();
            return result;
        }

        private string ConvertFromSnakeCase(string input)
        {
            string[] parts = input.Split('_');
            return string.Join("", parts.Select(part => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(part.ToLower())));
        }

        private bool IsUppercasedSnakeCase(string input)
        {
            string pattern = @"^[A-Z]+(_[A-Z]+)*$";
            return Regex.IsMatch(input, pattern);
        }
    }
}
