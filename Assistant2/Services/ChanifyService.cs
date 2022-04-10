using System.Net;
using System.Text;
using Assistant2.Dao;
using Assistant2.Models;
using Newtonsoft.Json;

namespace Assistant2.Services;

public class ChanifyService : IAnnounceService
{
    private readonly AssistantDbContext _context;
    private readonly ILogger<ChanifyService> _logger;

    public ChanifyService(AssistantDbContext context,ILogger<ChanifyService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void SendDefault(string text)
    {
        Send(text);
    }

    private async void Send(string text, string title="",string copy="",int autocopy=0,int sound=0,int priority=10)
    {
        using var client = new HttpClient();
        var channel = _context.ChanifyChannels.Single(e => e.Id == 1);
        var url = $"https://{channel.Address}/v1/sender/{channel.Token}";
        var req = new ChanifyRequest
        {
            token = channel.Token,
            text = text,
            title = title,
            copy = copy,
            autocopy = autocopy,
            sound = sound,
            priority = priority
        };
        var json = JsonConvert.SerializeObject(req);
        var res = await client.PostAsync(url, new StringContent(json,Encoding.UTF8, "application/json"));
        if (res.StatusCode!=HttpStatusCode.OK)
        {
            _logger.LogWarning("消息发送失败！"+res.Content.ReadAsStringAsync().Result);
        }
    }
 
}