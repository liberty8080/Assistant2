using System.ComponentModel.DataAnnotations.Schema;

namespace Assistant2.Models;

public class MagicSubHistory
{
    [Column(Order = 0)] 
    public int Id { get; set; }

    [Column(Order = 1)] 
    public int SubId { get; set; }

    [Column(Order = 2)] 
    public DateTime ExpirationTime { get; set; }

    [Column(Order = 3)]
    public DateTime UpdateTime { get; set; }

    [Column(Order = 4)] 
    public string Data { get; set; } = string.Empty;

    [Column(Order = 5)] 
    public double BandwidthLeft { get; set; } // 单位：GB
}