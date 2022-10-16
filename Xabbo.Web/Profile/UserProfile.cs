namespace Xabbo.Web;

public class UserProfile
{
    [JsonPropertyName("user")]
    public ExtendedUserInfo UserInfo { get; set; } = new();

    [JsonPropertyName("groups")]
    public List<GroupInfo> Groups { get; set; } = new();

    [JsonPropertyName("badges")]
    public List<BadgeInfo> Badges { get; set; } = new();

    [JsonPropertyName("friends")]
    public List<BasicUserInfo> Friends { get; set; } = new();

    [JsonPropertyName("rooms")]
    public List<UserRoomInfo> Rooms { get; set; } = new();
}
