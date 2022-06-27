namespace Assistant2.Models;

public class DDNSHistory
{
    public int Id { get; set; }
    public string Ipv4 { get; set; } = "";
    public string Ipv6 { get; set; } = "";
    public DateTime UpdateTime { get; set; }
    public int ConfigId { get; set; }
}