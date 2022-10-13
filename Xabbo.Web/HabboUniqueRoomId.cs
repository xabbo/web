using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace Xabbo.Web;

/// <summary>
/// Represents a globally unique room identifier.
/// </summary>
public readonly struct HabboUniqueRoomId
{
    /// <summary>
    /// Gets the hotel identifier.
    /// </summary>
    public string Hotel { get; }

    /// <summary>
    /// Gets the hash.
    /// </summary>
    public string Hash { get; }

    public HabboUniqueRoomId(string hotel, string hash)
    {
        if (hotel.Length != 2)
            throw new FormatException("Hotel must be a 2-character identifier.");

        Hotel = hotel.ToLower();
        Hash = hash.ToLower();
    }

    public override string ToString() => $"r-hh{Hotel}-{Hash}";

    public override int GetHashCode() => (Hotel, Hash).GetHashCode();
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj switch
        {
            HabboUniqueRoomId other => Equals(other),
            string uniqueId => Equals(uniqueId),
            _ => false
        };
    }
    public bool Equals(string uniqueId) => ToString().Equals(uniqueId, StringComparison.OrdinalIgnoreCase);
    public bool Equals(HabboUniqueRoomId other) =>
        Hotel.Equals(other.Hotel, StringComparison.OrdinalIgnoreCase) &&
        Hash.Equals(other.Hash, StringComparison.OrdinalIgnoreCase);

    public static bool operator ==(HabboUniqueRoomId left, HabboUniqueRoomId right) => left.Equals(right);
    public static bool operator !=(HabboUniqueRoomId left, HabboUniqueRoomId right) => !(left == right);
    public static bool operator ==(HabboUniqueRoomId left, string right) => left.Equals(right);
    public static bool operator !=(HabboUniqueRoomId left, string right) => !(left == right);
    public static bool operator ==(string left, HabboUniqueRoomId right) => right.Equals(left);
    public static bool operator !=(string left, HabboUniqueRoomId right) => !(left == right);

    public static implicit operator string(HabboUniqueRoomId uniqueId) => uniqueId.ToString();
    public static explicit operator HabboUniqueRoomId(string idString) => HabboUniqueRoomId.Parse(idString);

    public static HabboUniqueRoomId Parse(string idString)
    {
        if (!HabboApiUtil.IsUniqueRoomId(idString))
            throw new FormatException("Invalid unique room ID format.");

        return new HabboUniqueRoomId(idString[4..6], idString[^32..]);
    }
}
