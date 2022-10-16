using System.Diagnostics.CodeAnalysis;
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

    public static UniqueHabboRoomId Parse(string s)
        => TryParse(s, out var uniqueId) ? uniqueId : throw new FormatException($"Invalid unique room ID format: '{s}'.");

    public static bool TryParse(string s, [NotNullWhen(true)] out UniqueHabboRoomId? uniqueId)
        => (uniqueId = IsValid(s) ? new(s[2..4], s[^32..]) : null) is not null;
}
