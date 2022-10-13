using System.Text.Json;

namespace Xabbo.Web.Serialization;

public class UserInfoConverter : JsonConverter<UserInfoBase>
{
    public override UserInfoBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonDocument doc = JsonDocument.ParseValue(ref reader);

        if (doc.RootElement.TryGetProperty("profileVisible", out JsonElement value))
        {
            if (value.GetBoolean())
            {
                return doc.Deserialize<ExtendedUserInfo>(options);
            }
            else
            {
                return doc.Deserialize<UserInfo>(options);
            }
        }

        return doc.Deserialize<BasicUserInfo>(options);
    }

    public override void Write(Utf8JsonWriter writer, UserInfoBase value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case ExtendedUserInfo extendedUserInfo:
                JsonSerializer.Serialize(writer, extendedUserInfo, options);
                break;
            case UserInfo userInfo:
                JsonSerializer.Serialize(writer, userInfo, options);
                break;
            case BasicUserInfo basicUserInfo:
                JsonSerializer.Serialize(writer, basicUserInfo, options);
                break;
            default:
                throw new JsonException($"Unsupported type: {value.GetType().FullName}.");
        }
    }
}
