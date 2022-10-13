namespace Xabbo.Web;

public class PhotoInfo
{
    [JsonPropertyName("t")]
    public long Time { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}
