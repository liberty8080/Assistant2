using Assistant2.Dao;
using Assistant2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnounceController
{
    private readonly IAnnounceService _service;
    private readonly ILogger<AnnounceController> _logger;

    public AnnounceController(IAnnounceService service,
        ILogger<AnnounceController> logger)
    {
        _service = service;
        _logger = logger;
    }
    [HttpGet("send")]
    public void Send(string msg)
    {
        _service.SendDefault("test");
    }


 }