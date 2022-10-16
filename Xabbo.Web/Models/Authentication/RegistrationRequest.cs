using System.ComponentModel;

namespace Xabbo.Web;

public class RegistrationRequest
{
    [JsonPropertyName("captchaToken")]
    public string? CaptchaToken { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [JsonPropertyName("passwordRepeated")]
    public string PasswordRepeated => Password;

    [JsonPropertyName("birthdate")]
    public DateOnly Birthdate { get; set; }

    [JsonPropertyName("termsOfServiceAccepted")]
    public bool TermsOfServiceAccepted { get; set; }

    public RegistrationRequest(string email, string password, DateOnly birthdate)
    {
        Email = email;
        Password = password;
        Birthdate = birthdate;
        TermsOfServiceAccepted = true;
    }

    public RegistrationRequest()
        : this(string.Empty, string.Empty, default)
    { }
}
