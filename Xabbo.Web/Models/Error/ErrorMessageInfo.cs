namespace Xabbo.Web;

public class ErrorMessageInfo
{
    [JsonPropertyName("errorMsg")]
    public string ErrorMessage { get; set; } = string.Empty;
}
