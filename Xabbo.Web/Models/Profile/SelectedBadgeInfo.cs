namespace Xabbo.Web;

public class SelectedBadgeInfo : BadgeInfo
{
    [JsonPropertyName("badgeIndex")]
    public int Index { get; set; }
}
