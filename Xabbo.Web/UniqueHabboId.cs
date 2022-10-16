using System.Text.RegularExpressions;

namespace Xabbo.Web;

/// <summary>
/// Represents a globally unique Habbo identifier.
/// </summary>
public abstract class UniqueHabboId : IEquatable<UniqueHabboId>
{
    private static readonly Regex
        RegexUniqueId = new(@"^([rg]-)?hh[a-z0-9]{2}-[0-9a-f]{32}$"),
        RegexHotel = new(@"^[a-z0-9]{2}$", RegexOptions.Compiled),
        RegexHash = new(@"^[0-9a-f]{32}$", RegexOptions.Compiled);

    /// <summary>
    /// Gets the type of this identifier.
    /// </summary>
    public UniqueHabboIdType Type { get; }

    /// <summary>
    /// Gets the hotel component of this identifier.
    /// </summary>
    public string Hotel { get; }

    /// <summary>
    /// Gets the hash component of this identifier.
    /// </summary>
    public string Hash { get; }

    protected UniqueHabboId(UniqueHabboIdType type)
        : this(type, "xx", new string('0', 32))
    { }

    protected UniqueHabboId(UniqueHabboIdType type, string hotel, string hash)
    {
        ArgumentNullException.ThrowIfNull(hotel);
        ArgumentNullException.ThrowIfNull(hash);

        if (!Enum.IsDefined(type))
            throw new ArgumentException("Unknown HabboUniqueIdType.", nameof(type));
        if (!RegexHotel.IsMatch(hotel))
            throw new ArgumentException("Invalid hotel. Must be a 2-character identifier.", nameof(hotel));
        if (!RegexHash.IsMatch(hash))
            throw new ArgumentException("Invalid hash. Must be a 32-character lowercase hexadecimal number.", nameof(hash));

        Type = type;
        Hotel = hotel;
        Hash = hash;
    }

    public override int GetHashCode() => HashCode.Combine(Type, Hotel, Hash);
    public override bool Equals(object? obj) => obj is UniqueHabboId other && Equals(other);
    public bool Equals(UniqueHabboId? other)
    {
        return
            other is not null &&
            Type == other.Type &&
            Hotel.Equals(other.Hotel) &&
            Hash.Equals(other.Hash);
    }

    public static bool IsValid(string uniqueId) => RegexUniqueId.IsMatch(uniqueId);

    public static bool operator ==(UniqueHabboId? left, UniqueHabboId? right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(UniqueHabboId? left, UniqueHabboId? right) => !(left == right);

    public static implicit operator string(UniqueHabboId uniqueId) => $"{uniqueId}";
}