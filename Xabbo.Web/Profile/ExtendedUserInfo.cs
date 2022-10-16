namespace Xabbo.Web;

/// <summary>
/// Extended user information available when the user's profile is visible.
/// </summary>
public class ExtendedUserInfo : UserInfo
{
    [JsonPropertyName("online")]
    public bool IsOnline { get; set; }

    [JsonPropertyName("lastAccessTime")]
    public DateTime? LastAccessTime { get; set; }

    [JsonPropertyName("currentLevel")]
    public int CurrentLevel { get; set; }

    [JsonPropertyName("currentLevelCompletePercent")]
    public int CurrentLevelCompletePercent { get; set; }

    [JsonPropertyName("totalExperience")]
    public int TotalExperience { get; set; }

    [JsonPropertyName("starGemCount")]
    public int StarGemCount { get; set; }
}
