using System.Text.RegularExpressions;

namespace Xabbo.Web;

/// <summary>
/// Represents a globally unique Habbo group identifier.
/// </summary>
public sealed class UniqueHabboGroupId : UniqueHabboId
{
    public static readonly UniqueHabboGroupId None = new();

    private static readonly Regex
        RegexUniqueRoomId = new(@"^g-hh[a-z0-9]{2}-[0-9a-f]{32}$", RegexOptions.Compiled);

    private UniqueHabboGroupId()
        : base(UniqueHabboIdType.Group)
    { }

    public UniqueHabboGroupId(string hotel, string hash)
        : base(UniqueHabboIdType.User, hotel, hash)
    { }

    public static explicit operator UniqueHabboGroupId(string uniqueId) => Parse(uniqueId);

    public static new bool IsValid(string uniqueId) => RegexUniqueRoomId.IsMatch(uniqueId);

    public static UniqueHabboGroupId Parse(string uniqueId)
    {
        if (!RegexUniqueRoomId.IsMatch(uniqueId))
            throw new FormatException($"Invalid unique group ID format: '{uniqueId}'.");

        return new(uniqueId[2..4], uniqueId[^32..]);
    }
}
