namespace Xabbo.Web;

/// <summary>
/// Defines a user's information.
/// </summary>
public class UserInfo : BasicUserInfo
{
    [JsonPropertyName("memberSince")]
    public DateTime Created { get; set; }

    [JsonPropertyName("profileVisible")]
    public bool IsProfileVisible { get; set; }

    [JsonPropertyName("selectedBadges")]
    public List<SelectedBadgeInfo> SelectedBadges { get; set; } = new();
}
