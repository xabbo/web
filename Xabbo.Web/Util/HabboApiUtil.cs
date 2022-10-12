using System.Text.RegularExpressions;

namespace Xabbo.Web;

public static class HabboApiUtil
{
    private static readonly Regex
        _regexUniqueUserId = new(@"^hh[a-z0-9]{2}-[0-9a-f]{32}$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        _regexUniqueRoomId = new(@"^r-hh[a-z0-9]{2}-[0-9a-f]{32}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// Gets whether the specified string is a unique user ID.
    /// </summary>
    public static bool IsUniqueUserId(string s) => _regexUniqueUserId.IsMatch(s);

    /// <summary>
    /// Gets whether the specified string is a unique room ID.
    /// </summary>
    public static bool IsUniqueRoomId(string s) => _regexUniqueRoomId.IsMatch(s);
}
