namespace Xabbo.Web;

public sealed class UserNotFoundException : Exception
{
    private static string BuildMessage(HabboUniqueUserId? uniqueId, string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
            return $"User '{name}' was not found.";
        else if (uniqueId.HasValue)
            return $"User with ID '{uniqueId}' was not found.";
        else
            return "User was not found.";
    }

    public HabboUniqueUserId? UniqueId { get; }
    public string? Name { get; }

    public UserNotFoundException(HabboUniqueUserId? uniqueId, string? name)
        : base(BuildMessage(uniqueId, name))
    {
        UniqueId = uniqueId;
        Name = name;
    }
}
