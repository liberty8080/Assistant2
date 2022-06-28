using System.Net;
using Assistant2.Dao;
using Assistant2.Models;

namespace Assistant2.Services.DDNS;

// no support for multiple hostname
// todo: piece of shit,thinking and rewrite
public class DDnsService
{
    private readonly AssistantDbContext _dbContext;
    private IPAddress PreviousIp { get; set; }
    private readonly HttpClient _client = new();
    private IPAddress CurrentIp { get; set; }

    public DDnsService(AssistantDbContext dbContext)
    {
        _dbContext = dbContext;
        if (!dbContext.DdnsHistories.Any())
        {
            dbContext.Add(new DDNSHistory() {ConfigId = 1,});
        }

        var ipv4 = dbContext.DdnsHistories.OrderByDescending(h => h.UpdateTime).First().Ipv4;
        PreviousIp = IPAddress.Parse(ipv4);
    }


    /// <summary>
    /// Query public ip ,v4 only
    /// </summary>
    /// <returns></returns>
    public async Task QueryIp()
    {
        var ip = await _client.GetAsync("https://myip.ipip.net/s").Result
            .Content.ReadAsStringAsync();
        CurrentIp = IPAddress.Parse(ip.Replace("\n", ""));
    }

    // dynu api
    public void CheckIpAndDns(IPAddress ip)
    {
        if (!PreviousIp.Equals(ip))
        {
            Console.WriteLine($"old IP:{PreviousIp},new IP: {ip}");
            var ddnsConfig = _dbContext.DdnsConfigs.First();
            //do update if success then
            if (!ddnsConfig.Enable) return;
            _client.GetAsync($"https://api.dynu.com/nic/update?hostname={ddnsConfig.Hostname}&myip={CurrentIp}");
            // PreviousIp = ip;
        }
        else
        {
            Console.WriteLine("ip no change");
        }
    }
}