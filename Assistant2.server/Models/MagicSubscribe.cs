namespace Assistant2.Models;

public enum MagicSubscribeType
{
    V2,
    Rocket,
}

public class MagicSubscribe
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string ExpirationTime { get; set; } = string.Empty;
    public string BandwidthLeft { get; set; } = string.Empty;
    public MagicSubscribeType Type { get; set; }
    public string Data { get; set; } = string.Empty;
    public string Cron { get; set; } = string.Empty;
    public string RocketRegex { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}