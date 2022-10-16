using System.Text.Json;

namespace Xabbo.Web.Serialization;

public class HabboUniqueGroupIdConverter : JsonConverter<UniqueHabboGroupId?>
{
    public override UniqueHabboGroupId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? uniqueId = reader.GetString();
        if (uniqueId is null)
            return null;
        return UniqueHabboGroupId.Parse(uniqueId);
    }

    public override void Write(Utf8JsonWriter writer, UniqueHabboGroupId? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString());
    }
}