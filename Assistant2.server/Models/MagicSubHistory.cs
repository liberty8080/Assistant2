namespace Assistant2.Models;

public class MagicSubHistory
{
    public int Id { get; set; }
    public int SubId { get; set; }
    public DateTime ExpirationTime { get; set; }
    public DateTime UpdateTime { get; set; }
    public string Data { get; set; } = string.Empty;
    public double BandwidthLeft { get; set; } // 单位：GB
}