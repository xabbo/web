namespace Xabbo.Web;

public class PhotoNotFoundException : Exception
{
    public Guid Id { get; }

    public PhotoNotFoundException(Guid id)
        : base($"Photo with ID '{id}' not found.")
    {
        Id = id;
    }
}
