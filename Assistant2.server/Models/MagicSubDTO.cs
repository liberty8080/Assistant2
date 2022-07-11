namespace Assistant2.Models;

public class MagicSubDto
{
    public MagicSubDto( MagicSubscribe subscribe,MagicSubHistory? history)
    {
        Id = subscribe.Id;
        Name = subscribe.Name;
        Url = subscribe.Url;
        Type = (int)subscribe.Type;
        Cron = subscribe.Cron;
        RocketRegex = subscribe.RocketRegex;
        Comment = subscribe.Comment;
        if (history == null) return;
        ExpirationTime = history.ExpirationTime.ToString("yyyy-MM-dd HH:mm:ss");
        UpdateTime = history.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss");
        Data = history.Data;
        BandwidthLeft = history.BandwidthLeft;
    }

    public int Id { get; }
    public string Name { get; }
    public string Url { get; }
    public int Type { get; }
    public string Cron { get; }
    public string RocketRegex { get; }
    public string Comment { get; }
    public string? ExpirationTime { get; }
    public string? UpdateTime { get; }
    public string Data { get; } = string.Empty;
    public double BandwidthLeft { get; } // 单位：GB
}