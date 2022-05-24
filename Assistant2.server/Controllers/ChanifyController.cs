using Assistant2.Models;
using Assistant2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public ApiResult GetAll()
    {   
        return ApiResult.Success(_service.ChannelsAll());
    }

    [HttpPost("getbytype")]
    public ApiResult GetByType(ChanifyChannelType type)
    {
        try
        {
            return ApiResult.Success(_service.Channels(type));
        }
        catch (Exception e)
        {
            _logger.LogError("chanify 查询失败！cause:{Msg}",e.Message);
            return ApiResult.Success(null);
        }
    }

    [HttpPost("update")]
    public ApiResult Update(ChanifyChannel channel)
    {
        var state = _service.Update(channel);
        var msg = state switch
        {
            EntityState.Added => "添加成功",
            EntityState.Modified => "修改成功",
            _ => ""
        };

        return new ApiResult {Code = 200, Data = null, Msg = msg};
    }

    [HttpDelete("{id:int}")]
    public ApiResult Remove(int id)
    {
        try
        {
            _service.Remove(id);
            return ApiResult.Success(null);
        }
        catch (Exception)
        {
            return ApiResult.Failed(10000,"删除失败");
        }
    }
}