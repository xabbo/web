namespace Xabbo.Web;

/// <summary>
/// Represents a photo time and ID.
/// Stored in the wall item data of a photo.
/// </summary>
public class PhotoTimeId
{
    [JsonPropertyName("t")]
    public long Time { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}
