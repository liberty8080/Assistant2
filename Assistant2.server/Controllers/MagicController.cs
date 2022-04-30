using Assistant2.Models;
using Assistant2.Services.Magic;
using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers;

[ApiController]
[Route("[controller]")]
public class MagicController
{
    private readonly MagicSubscribeService _service;
    private readonly ILogger<MagicController> _logger;

    public MagicController(MagicSubscribeService service,ILogger<MagicController> logger)
    {
        _service = service;
        _logger = logger;
    }
    
    [HttpGet("all")]
    public IEnumerable<MagicSubscribe> All()
    {
        return _service.Subscribes();
    }

    [HttpGet("update")]
    public void UpdateById(int id)
    {
        _service.UpdateById(id);
    }

    [HttpPost("edit")]
    public void Edit(MagicSubscribe subscribe)
    {
        _service.Edit(subscribe);
    }

    [HttpPost("remove")]
    public void Remove(MagicSubscribe subscribe)
    {
        _service.Remove(subscribe);
    }
    
}