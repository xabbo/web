using System.Text.Json;

namespace Xabbo.Web.Serialization;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string dateString = reader.GetString() ?? throw new FormatException("Date/time cannot be null.");
        return DateTime.Parse(dateString);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd'T'HH:mm:ss.fff+0000"));
    }
}