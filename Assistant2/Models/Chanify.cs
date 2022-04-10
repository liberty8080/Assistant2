namespace Assistant2.Models;

public class ChanifyChannel
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Token { get; set; }
    public string? Comment { get; set; }
    public string Type { get; set; }
}


public class ChanifyRequest
{
    public string token { get; set; }
    public string title { get; set; }
    public string text { get; set; }
    public string copy { get; set; }
    public int autocopy { get; set; }
    public int sound { get; set; }
    public int priority { get; set; }
    
    public List <string > actions { get; set; }
}


