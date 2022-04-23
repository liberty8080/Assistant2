namespace Assistant2.Models;

public enum MagicSubscribeType
{
    Songuo,StarDream,Frog
}

public class MagicSubscribe
{
    public int Id { get; set; }
    public string Url { get; set; }
    public string ExpirationTime { get; set; }
    public string BandwidthLeft { get; set; }
    public MagicSubscribeType Type { get; set; }
    public string Data { get; set; }
    public string Site { get; set; }
    public bool AutoUpdate { get; set; }
    public int UpdateInterval { get; set; } // Hour
    public string Comment { get; set; }
}