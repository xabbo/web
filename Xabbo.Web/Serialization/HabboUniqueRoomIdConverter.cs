using System.Text.Json;

namespace Xabbo.Web.Serialization;

public class HabboUniqueRoomIdConverter : JsonConverter<UniqueHabboRoomId?>
{
    public override UniqueHabboRoomId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? uniqueId = reader.GetString();
        if (uniqueId is null)
            return null;
        return UniqueHabboRoomId.Parse(uniqueId);
    }

    public override void Write(Utf8JsonWriter writer, UniqueHabboRoomId? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString());
    }
}