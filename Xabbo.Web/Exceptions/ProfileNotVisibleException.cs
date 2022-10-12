namespace Xabbo.Web;

/// <summary>
/// Thrown when attempting to retrieve the profile of a user whose profile is not visible.
/// </summary>
public class ProfileNotVisibleException : Exception
{
    /// <summary>
    /// Gets the name of the user.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the user's information, if it is available.
    /// </summary>
    public UserInfo? User { get; }

    public ProfileNotVisibleException(string name, UserInfo? user = null)
    {
        Name = name;
        User = user;
    }
}
