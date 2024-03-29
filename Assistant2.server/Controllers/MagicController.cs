﻿using Assistant2.Models;
using Assistant2.Services.Magic;
using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers;

[ApiController]
[Route("[controller]")]
public class MagicController
{
    private readonly MagicSubscribeService _service;
    private readonly ILogger<MagicController> _logger;

    public MagicController(MagicSubscribeService service, ILogger<MagicController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("all")]
    public ApiResult All()
    {
        return ApiResult.Success(_service.Subscribes());
    }

    /// <summary>
    /// 更新订阅数据
    /// </summary>
    /// <param name="id">sub ID</param>
    /// <returns></returns>
    [HttpGet("update")]
    public ApiResult UpdateById(int id)
    {
        try
        {
            _service.UpdateById(id);
            return ApiResult.Success(null);
        }
        catch (Exception e)
        {
            _logger.LogError("订阅更新失败！Cause:{Msg}",e.ToString());
            return ApiResult.Failed("订阅更新失败！");
        }
    }


    [HttpPut]
    public ApiResult Edit(MagicSubscribe subscribe)
    {
        try
        {
            _service.Edit(subscribe);
            return ApiResult.Success(null);
        }
        catch (Exception e)
        {
            return ApiResult.Failed("更新失败!");
        }
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
            return ApiResult.Failed("删除失败！");
        }
    }

    [HttpPost]
    public ApiResult Add(MagicSubscribe subscribe)
    {
        try
        {
            _service.Add(subscribe);
            return ApiResult.Success(null);
        }
        catch (Exception e)
        {
            return ApiResult.Failed("添加失败！");
        }
    }
}