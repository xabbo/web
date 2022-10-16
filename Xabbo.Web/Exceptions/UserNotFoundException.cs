namespace Xabbo.Web;

public sealed class UserNotFoundException : Exception
{
    private static string BuildMessage(UniqueHabboUserId? uniqueId, string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
            return $"User '{name}' was not found.";
        else if (uniqueId is not null)
            return $"User with ID '{uniqueId}' was not found.";
        else
            return "User was not found.";
    }

    public UniqueHabboUserId? UniqueId { get; }
    public string? Name { get; }

    public UserNotFoundException(UniqueHabboUserId? uniqueId, string? name)
        : base(BuildMessage(uniqueId, name))
    {
        UniqueId = uniqueId;
        Name = name;
    }
}
