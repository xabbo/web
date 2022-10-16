using System.Text.Json;

namespace Xabbo.Web.Serialization;

public class UniqueHabboUserIdConverter : JsonConverter<UniqueHabboUserId?>
{
    public override UniqueHabboUserId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? uniqueId = reader.GetString();
        if (uniqueId is null)
            return null;
        return UniqueHabboUserId.Parse(uniqueId);
    }

    public override void Write(Utf8JsonWriter writer, UniqueHabboUserId? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString());
    }
}