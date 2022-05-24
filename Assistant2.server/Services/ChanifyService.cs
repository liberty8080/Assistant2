using System.Net;
using System.Text;
using System.Text.Json;
using Assistant2.Dao;
using Assistant2.Exceptions;
using Assistant2.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Assistant2.Services;

public class ChanifyService : IAnnounceService
{
    private readonly AssistantDbContext _context;
    private readonly ILogger<ChanifyService> _logger;

    public ChanifyService(AssistantDbContext context, ILogger<ChanifyService> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// 未分类消息，无标题
    /// </summary>
    /// <param name="text"></param>
    public void SendDefault(string text)
    {
        var channel = Channels(ChanifyChannelType.Default);
        foreach (var c in channel)
        {
            Send(c, text);
        }
    }

    /// <summary>
    /// magic频道，标题，声音
    /// </summary>
    /// <param name="text"></param>
    /// <param name="title"></param>
    /// <param name="sound"></param>
    public void SendMagic(string text, string title, int sound)
    {
        var channel = Channels(ChanifyChannelType.Magic);

        foreach (var c in channel)
        {
            Send(c, text, title, sound: sound);
        }
    }

    private async void Send(ChanifyChannel channel, string text, string title = "",
        string copy = "", int autocopy = 0, int sound = 1, int priority = 10)
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
        var json = JsonConvert.SerializeObject(req, new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        });
        var res = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

        if (res.StatusCode != HttpStatusCode.OK)
        {
            var msg = res.Content.ReadAsStringAsync().Result;
            _logger.LogWarning("消息发送失败！{Msg}", msg);
            throw new AnnounceException($"消息发送失败!{msg}");
        }

        _logger.LogInformation("消息发送成功！{Comment}:{Text}",
            channel.Comment, req.Text);
    }

    /// <summary>
    /// get channels by type,should not be empty list
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="MagicException"></exception>
    public IEnumerable<ChanifyChannel> Channels(ChanifyChannelType type)
    {
        var channel = _context.ChanifyChannels
            .Where(e => e.Type == type).ToList();
        if (channel.Any()) return channel;

        throw new MagicException($"unable to get {type} channels! consider add one");
    }

    /// <summary>
    /// get all channels
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ChanifyChannel> ChannelsAll()
    {
        var channels = _context.ChanifyChannels;
        return channels;
    }

    public EntityState Update(ChanifyChannel channel)
    {
        var ss = _context.ChanifyChannels.Update(channel).State;
        _context.SaveChanges();
        return ss;
    }

    public void Remove(int id)
    {
        _context.ChanifyChannels.Remove(new ChanifyChannel{Id = id});
        _context.SaveChanges();
    }
}