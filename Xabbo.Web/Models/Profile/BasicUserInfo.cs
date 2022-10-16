using Xabbo.Web.Serialization;

namespace Xabbo.Web;

/// <summary>
/// Defines a user's basic information.
/// </summary>
public class BasicUserInfo : UserInfoBase
{
    [JsonPropertyName("uniqueId")]
    public UniqueHabboUserId UniqueId { get; set; } = UniqueHabboUserId.None;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("figureString")]
    public string FigureString { get; set; } = string.Empty;

    [JsonPropertyName("motto")]
    public string Motto { get; set; } = string.Empty;
}
