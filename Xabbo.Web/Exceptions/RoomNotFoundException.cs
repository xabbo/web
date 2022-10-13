namespace Xabbo.Web;

public class RoomNotFoundException : Exception
{
    public long RoomId { get; }

    public RoomNotFoundException(long roomId)
        : base($"Room {roomId} was not found.")
    {
        RoomId = roomId;
    }
}
