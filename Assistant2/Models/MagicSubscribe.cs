namespace Assistant2.Models;

public enum MagicSubscribeType
{
    Songuo,StarDream
}

public class MagicSubscribe
{
    public int Id { get; set; }
    public string Url { get; set; }
    public DateTime ExpirationTime { get; set; }
    public string BandwidthLeft { get; set; }
    public MagicSubscribeType Type { get; set; }
    public string Data { get; set; }
    public string Comment { get; set; }
}