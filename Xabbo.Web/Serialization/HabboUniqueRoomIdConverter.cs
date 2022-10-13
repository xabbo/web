using System.Text.Json;

namespace Xabbo.Web.Serialization;

public class HabboUniqueRoomIdConverter : JsonConverter<HabboUniqueRoomId>
{
    public override HabboUniqueRoomId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string uniqueId = reader.GetString() ?? throw new FormatException($"Habbo unique room ID was null.");
        return HabboUniqueRoomId.Parse(uniqueId);
    }

    public override void Write(Utf8JsonWriter writer, HabboUniqueRoomId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}