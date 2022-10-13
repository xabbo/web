namespace Xabbo.Web;

public class PhotoData
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.Empty;

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    [JsonPropertyName("room_id")]
    public int RoomId { get; set; }

    [JsonPropertyName("creator_uniqueId")]
    public HabboUniqueUserId CreatorUniqueId { get; set; }

    [JsonPropertyName("creator_id")]
    public int CreatorId { get; set; }

    [JsonPropertyName("creator_name")]
    public string CreatorName { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("previewUrl")]
    public string PreviewUrl { get; set; } = string.Empty;
}
