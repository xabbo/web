namespace Xabbo.Web;

public class RoomInfo : UserRoomInfo
{
    [JsonPropertyName("publicRoom")]
    public bool IsPublicRoom { get; set; }

    [JsonPropertyName("doorMode")]
    public string DoorMode { get; set; } = string.Empty;
}
