using System.Text.Json;

namespace Xabbo.Web.Serialization;

public class HabboUniqueUserIdConverter : JsonConverter<HabboUniqueUserId>
{
    public override HabboUniqueUserId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string uniqueId = reader.GetString() ?? throw new FormatException($"Habbo unique user ID was null.");
        return HabboUniqueUserId.Parse(uniqueId);
    }

    public override void Write(Utf8JsonWriter writer, HabboUniqueUserId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}