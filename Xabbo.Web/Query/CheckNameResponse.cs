namespace Xabbo.Web;

public class CheckNameResponse
{
    [JsonPropertyName("isAvailable")]
    public bool IsAvailable { get; set; }
}
