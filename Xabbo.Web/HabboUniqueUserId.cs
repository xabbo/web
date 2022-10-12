using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace Xabbo.Web;

/// <summary>
/// Represents a globally unique user identifier.
/// </summary>
public readonly struct HabboUniqueUserId
{
    /// <summary>
    /// Gets the hotel identifier.
    /// </summary>
    public string Hotel { get; }

    /// <summary>
    /// Gets the ID.
    /// </summary>
    public ulong Id { get; }

    public HabboUniqueUserId(string hotel, ulong id)
    {
        if (hotel.Length != 2)
            throw new FormatException("Hotel must be a 2-character identifier.");

        Hotel = hotel;
        Id = id;
    }

    public override string ToString() => $"hh{Hotel}-{Id:x32}";

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

    public bool Equals(HabboUniqueUserId other) => Hotel.Equals(other.Hotel, StringComparison.OrdinalIgnoreCase) && Id == other.Id;
    public bool Equals(string uniqueId) => ToString().Equals(uniqueId, StringComparison.OrdinalIgnoreCase);

    public static bool operator ==(HabboUniqueUserId left, HabboUniqueUserId right) => left.Equals(right);
    public static bool operator !=(HabboUniqueUserId left, HabboUniqueUserId right) => !(left == right);
    public static bool operator ==(HabboUniqueUserId left, string right) => left.Equals(right);
    public static bool operator !=(HabboUniqueUserId left, string right) => !(left == right);
    public static bool operator ==(string left, HabboUniqueUserId right) => right.Equals(left);
    public static bool operator !=(string left, HabboUniqueUserId right) => !(left == right);

    public static implicit operator string(HabboUniqueUserId uniqueId) => uniqueId.ToString();
    public static explicit operator HabboUniqueUserId(string idString) => HabboUniqueUserId.Parse(idString);

    public static HabboUniqueUserId Parse(string idString)
    {
        if (!HabboApiUtil.IsUniqueUserId(idString))
            throw new FormatException("Invalid unique user ID format specified.");

        string hotel = idString[2..4];
        ulong id = ulong.Parse(idString[^32..], NumberStyles.HexNumber, CultureInfo.InvariantCulture);

        return new HabboUniqueUserId(hotel, id);
    }
}
