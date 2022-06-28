namespace Assistant2.Models;

public class MagicSubHistory
{
    public int Id { get; set; }
    public int SubId { get; set; }
    public DateTime UpdateTime { get; set; }
    public double BandWidthLeft { get; set; } // 单位：GB
}