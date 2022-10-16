namespace Xabbo.Web;

public class AvatarInfo
{
    /// <summary>
    /// The globally unique user identifier of this avatar.
    /// </summary>
    [JsonPropertyName("uniqueId")]
    public UniqueHabboUserId UniqueId { get; set; } = UniqueHabboUserId.None;

    /// <summary>
    /// The name of this avatar.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The figure string of this avatar.
    /// </summary>
    [JsonPropertyName("figureString")]
    public string FigureString { get; set; } = string.Empty;

    /// <summary>
    /// The motto of this avatar.
    /// </summary>
    [JsonPropertyName("motto")]
    public string Motto { get; set; } = string.Empty;

    /// <summary>
    /// Whether this avatar is a builder's club member.
    /// </summary>
    [JsonPropertyName("buildersClubMember")]
    public bool BuildersClubMember { get; set; }

    /// <summary>
    /// Whether this avatar is a Habbo club member.
    /// </summary>
    [JsonPropertyName("habboClubMember")]
    public bool HabboClubMember { get; set; }

    /// <summary>
    /// The time this avatar was created.
    /// </summary>
    [JsonPropertyName("creationTime")]
    public DateTime Created { get; set; }

    /// <summary>
    /// The time this avatar was last accessed.
    /// </summary>
    [JsonPropertyName("lastWebAccess")]
    public DateTime? LastAccess { get; set; }

    /// <summary>
    /// Whether this avatar is banned.
    /// </summary>
    [JsonPropertyName("banned")]
    public bool Banned { get; set; }

    [JsonPropertyName("errorMsg")]
    public string Error { get; set; } = string.Empty;
}