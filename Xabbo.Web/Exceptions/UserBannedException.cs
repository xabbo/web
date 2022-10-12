namespace Xabbo.Web;

/// <summary>
/// Thrown when attempting to retrieve the profile of a user who is banned.
/// </summary>
public class UserBannedException : Exception
{
    /// <summary>
    /// Gets the name of the user.
    /// </summary>
    public string? Name { get; }

    public UserBannedException(string? name)
    {
        Name = name;
    }
}
