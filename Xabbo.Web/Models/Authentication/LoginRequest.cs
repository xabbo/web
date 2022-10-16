namespace Xabbo.Web;

public class LoginRequest
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("captchaToken")]
    public string CaptchaToken { get; set; } = string.Empty;
}
