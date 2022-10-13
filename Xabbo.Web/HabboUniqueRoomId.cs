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
    /// Gets the ID.
    /// </summary>
    public ulong Id { get; }

    public HabboUniqueRoomId(string hotel, ulong id)
    {
        if (hotel.Length != 2)
            throw new FormatException("Hotel must be a 2-character identifier.");

        Hotel = hotel;
        Id = id;
    }

    public override string ToString() => $"r-hh{Hotel}-{Id:x32}";

    public override int GetHashCode() => (Hotel, Id).GetHashCode();
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj switch
        {
            HabboUniqueUserId other => Equals(other),
            string uniqueId => Equals(uniqueId),
            _ => false
        };
    }

    public bool Equals(HabboUniqueRoomId other) => Hotel.Equals(other.Hotel, StringComparison.OrdinalIgnoreCase) && Id == other.Id;
    public bool Equals(string uniqueId) => ToString().Equals(uniqueId, StringComparison.OrdinalIgnoreCase);

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

        string hotel = idString[4..6];
        ulong id = ulong.Parse(idString[^32..], NumberStyles.HexNumber, CultureInfo.InvariantCulture);

        return new HabboUniqueRoomId(hotel, id);
    }
}
