using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Xabbo.Web;

/// <summary>
/// Represents a globally unique Habbo user identifier.
/// </summary>
public sealed class UniqueHabboUserId : UniqueHabboId
{
    public static readonly UniqueHabboUserId None = new();

    private static readonly Regex
        RegexUniqueUserId = new(@"^hh[a-z0-9]{2}-[0-9a-f]{32}$", RegexOptions.Compiled);

    private UniqueHabboUserId()
        : base(UniqueHabboIdType.User)
    { }

    public UniqueHabboUserId(string hotel, string hash)
        : base(UniqueHabboIdType.User, hotel, hash)
    { }

    public static explicit operator UniqueHabboUserId(string uniqueId) => Parse(uniqueId);

    public static new bool IsValid(string uniqueId) => RegexUniqueUserId.IsMatch(uniqueId);

    public static UniqueHabboUserId Parse(string s)
        => TryParse(s, out var uniqueId) ? uniqueId : throw new FormatException($"Invalid unique user ID format: '{s}'.");

    public static bool TryParse(string s, [NotNullWhen(true)] out UniqueHabboUserId? uniqueId)
        => (uniqueId = IsValid(s) ? new(s[2..4], s[^32..]) : null) is not null;
}
