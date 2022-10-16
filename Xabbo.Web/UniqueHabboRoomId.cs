using System.Text.RegularExpressions;

namespace Xabbo.Web;

/// <summary>
/// Represents a globally unique Habbo room identifier.
/// </summary>
public sealed class UniqueHabboRoomId : UniqueHabboId
{
    public static readonly UniqueHabboRoomId None = new();

    private static readonly Regex
        RegexUniqueRoomId = new(@"^r-hh[a-z0-9]{2}-[0-9a-f]{32}$", RegexOptions.Compiled);

    private UniqueHabboRoomId()
        : base(UniqueHabboIdType.Room)
    { }

    public UniqueHabboRoomId(string hotel, string hash)
        : base(UniqueHabboIdType.User, hotel, hash)
    { }

    public static explicit operator UniqueHabboRoomId(string uniqueId) => Parse(uniqueId);

    public static new bool IsValid(string uniqueId) => RegexUniqueRoomId.IsMatch(uniqueId);

    public static UniqueHabboRoomId Parse(string uniqueId)
    {
        if (!RegexUniqueRoomId.IsMatch(uniqueId))
            throw new FormatException($"Invalid Habbo unique room ID format: '{uniqueId}'.");

        return new(uniqueId[2..4], uniqueId[^32..]);
    }
}
