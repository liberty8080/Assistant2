using Assistant2.Dao;
using Assistant2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnounceController
{
    private readonly IAnnounceService _service;
    private readonly AssistantDbContext _context;
    private readonly ILogger<AnnounceController> _logger;

    public AnnounceController(IAnnounceService service,
        AssistantDbContext context,
        ILogger<AnnounceController> logger)
    {
        _service = service;
        _context = context;
        _logger = logger;
    }
    [HttpGet]
    public void Send()
    {
        _service.SendDefault("test");
    }
}