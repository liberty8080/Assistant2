using System.Net;
using System.Text;
using System.Text.Json;
using Assistant2.Dao;
using Assistant2.Exceptions;
using Assistant2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
        var channel = _context.ChanifyChannels
            .Where(e => e.Id == 1).ToList();
        if (!channel.Any())
        {
            _logger.LogWarning("unable to send chanify,no default server");
            return;
        }
        foreach (var c in channel)
        {
            Send(c,text);
        }
    }

    public void SendMagic(string text, string title,int sound)
    {
        var channel = _context.ChanifyChannels
            .Where(e => e.Type == ChanifyChannelType.Magic).ToList();
        if (!channel.Any())
        {
            _logger.LogWarning("unable to send chanify,no magic server");
            return;
        }
        foreach (var c in channel)
        {
            Send(c,text,title,sound:sound);
        }
    }

    private async void Send(ChanifyChannel channel,string text, string title="",
        string copy="",int autocopy=0,int sound=1,int priority=10)
    {
        using var client = new HttpClient();
        var url = $"https://{channel.Address}/v1/sender/{channel.Token}";
        var req = new ChanifyRequest
        {
            Token = channel.Token,
            Text = text,
            Title = title,
            Copy = copy,
            Autocopy = autocopy,
            Sound = sound,
            Priority = priority
        };
        var contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };
        var json = JsonConvert.SerializeObject(req,new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        });
        var res = await client.PostAsync(url, new StringContent(json,Encoding.UTF8, "application/json"));
        
        if (res.StatusCode!=HttpStatusCode.OK)
        {
            var msg =  res.Content.ReadAsStringAsync().Result;
            _logger.LogWarning("消息发送失败！{Msg}",msg);
            throw new AnnounceException($"消息发送失败!{msg}");
        }

        _logger.LogInformation("消息发送成功！{Comment}:{Text}",
            channel.Comment,req.Text);
    }
 
}