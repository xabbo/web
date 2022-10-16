namespace Xabbo.Web;

public class GameDataInfoContainer
{
    [JsonPropertyName("hashes")]
    public List<GameDataInfo> Infos { get; set; } = new();
}
