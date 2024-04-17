using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace main.parser
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly string Format = "yyyy-MM-dd HH:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateStr = reader.GetString()!;
            DateTime.TryParseExact(dateStr, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
            return result;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
