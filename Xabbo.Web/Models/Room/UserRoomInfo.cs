namespace Xabbo.Web;

public class UserRoomInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("creationTime")]
    public DateTime Created { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    [JsonPropertyName("maximumVisitors")]
    public int MaximumVisitors { get; set; }

    [JsonPropertyName("showOwnerName")]
    public bool ShowOwnerName { get; set; }

    [JsonPropertyName("ownerName")]
    public string OwnerName { get; set; } = string.Empty;

    [JsonPropertyName("ownerUniqueId")]
    public UniqueHabboUserId OwnerUniqueId { get; set; } = UniqueHabboUserId.None;

    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; } = new();

    [JsonPropertyName("thumbnailUrl")]
    public string ThumbnailUrl { get; set; } = string.Empty;

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    [JsonPropertyName("rating")]
    public int Rating { get; set; }

    [JsonPropertyName("uniqueId")]
    public UniqueHabboRoomId UniqueId { get; set; } = UniqueHabboRoomId.None;
}
