namespace Xabbo.Web;

public class ErrorInfos
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;

    [JsonPropertyName("errors")]
    public List<ErrorInfo> Errors { get; set; } = new();
}
