namespace Xabbo.Web;

public class ProfileGroupInfo : GroupInfo
{
    [JsonPropertyName("isAdmin")]
    public bool IsAdmin { get; set; }
}
