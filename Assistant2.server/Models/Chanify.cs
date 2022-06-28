namespace Assistant2.Models;

public enum ChanifyChannelType
{
    Default,
    Magic
}

public class ChanifyChannel
{
    public int Id { get; set; }
    public string? Address { get; set; }
    public string? Token { get; set; }
    public string? Comment { get; set; }
    public ChanifyChannelType Type { get; set; }
}

public class ChanifyRequest
{
    public string? Token { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? Copy { get; set; }
    public int Autocopy { get; set; }
    public int Sound { get; set; }
    public int Priority { get; set; }
}