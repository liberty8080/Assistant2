namespace Assistant2.Models;

public class DDNSConfig
{
    public int Id { get; set; }
    public string Name { get; set; } = "MyDDNS";
    public string Hostname { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public bool Enable { get; set; }
    
}