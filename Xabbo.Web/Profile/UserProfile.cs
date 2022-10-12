namespace Xabbo.Web;

public class UserProfile
{
    [JsonIgnore] public HabboUniqueUserId UniqueId => UserInfo.UniqueId;
    [JsonIgnore] public string Name => UserInfo.Name;
    [JsonIgnore] public string FigureString => UserInfo.FigureString;
    [JsonIgnore] public string Motto => UserInfo.Motto;
    [JsonIgnore] public DateTime Created => UserInfo.Created;

    [JsonPropertyName("user")]
    public UserInfo UserInfo { get; set; } = new();

    [JsonPropertyName("groups")]
    public List<GroupInfo> Groups { get; set; } = new();

    [JsonPropertyName("badges")]
    public List<BadgeInfo> Badges { get; set; } = new();

    [JsonPropertyName("friends")]
    public List<BasicUserInfo> Friends { get; set; } = new();

    [JsonPropertyName("rooms")]
    public List<UserRoomInfo> Rooms { get; set; } = new();
}
