using Assistant2.Models;
using Assistant2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers;

[ApiController]
[Route("[controller]")]
public class ChanifyController
{
    private readonly ChanifyService _service;
    private readonly ILogger<ChanifyController> _logger;

    public ChanifyController(ChanifyService service,ILogger<ChanifyController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("all")]
    public IEnumerable<ChanifyChannel> GetAll()
    {
        return _service.ChannelsAll();
    }

    [HttpPost]
    public IEnumerable<ChanifyChannel> GetByType(ChanifyChannelType type)
    {
        try
        {
            return _service.Channels(type);
        }
        catch (Exception e)
        {
            _logger.LogError("chanify 查询失败！",e.Message);
            return new List<ChanifyChannel>();
        }
    }

    [HttpPost("update")]
    public void Update(ChanifyChannel channel)
    {
        _service.Update(channel);
    }

    [HttpPost("remove")]
    public void Remove(ChanifyChannel channel)
    {
        _service.Remove(channel);
    }
}