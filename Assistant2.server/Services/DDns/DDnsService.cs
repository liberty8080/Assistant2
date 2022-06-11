using System.Net;

namespace Assistant2.Services.DDns;

public class DDnsService
{
    private IPAddress PreviousIp { get; set; } = IPAddress.None;
    private readonly HttpClient _client = new();

    /// <summary>
    /// Query public ip ,v4 only
    /// </summary>
    /// <returns></returns>
    public async Task<IPAddress> QueryIp()
    {
        var ip = await _client.GetAsync("https://myip.ipip.net/s").Result
            .Content.ReadAsStringAsync();
        return IPAddress.Parse(ip.Replace("\n", ""));
    }

    // dynu api
    public void UpdateDnsRecord(IPAddress ip)
    {
        if (!PreviousIp.Equals(ip))
        {
            Console.WriteLine($"old IP:{PreviousIp},new IP: {ip}");
            //do update if success then
            PreviousIp = ip;
        }
        else
        {
            Console.WriteLine("ip no change");
        }

    }
}