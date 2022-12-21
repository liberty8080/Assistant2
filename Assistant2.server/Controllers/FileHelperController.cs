using Assistant2.Models;
using Assistant2.Services.FileHelper;
using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers;

[ApiController]
[Route("[controller]")]
public class FileHelperController
{
    private readonly FileHelperService _fileHelperService;
    private readonly DeleteService _deleteService;
    private readonly RenameService _renameService;
    private readonly ILogger<FileHelperController> _logger;

    public FileHelperController(FileHelperService fileHelperService,
        DeleteService deleteService,RenameService renameService,ILogger<FileHelperController> logger)
    {
        _fileHelperService = fileHelperService;
        _deleteService = deleteService;
        _renameService = renameService;
        _logger = logger;
    }

    [HttpGet("root")]
    public IEnumerable<FileInfoDto> ShowRootFiles()
    {
        return _fileHelperService.ShowRootFiles();
    }
}