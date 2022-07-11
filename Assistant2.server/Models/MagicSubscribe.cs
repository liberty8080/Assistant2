using System.ComponentModel.DataAnnotations.Schema;

namespace Assistant2.Models;

public enum MagicSubscribeType
{
    V2,
    Rocket,
}

public class MagicSubscribe
{
    [Column(Order = 0)] public int Id { get; set; }
    [Column(Order = 1)] public string Name { get; set; } = string.Empty;
    [Column(Order = 2)] public string Url { get; set; } = string.Empty;
    [Column(Order = 3)] public MagicSubscribeType Type { get; set; }
    [Column(Order = 4)] public string Cron { get; set; } = string.Empty;
    [Column(Order = 5)] public string RocketRegex { get; set; } = string.Empty;
    [Column(Order = 6)] public string Comment { get; set; } = string.Empty;
}