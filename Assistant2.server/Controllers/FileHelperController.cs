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
    public ApiResult ShowRootFiles()
    {
        return  ApiResult.Success(_fileHelperService.ShowRootFiles());
    }

    [HttpGet("walk")]
    public ApiResult Walk(string path)
    {
        try
        {

        }
        catch (Exception e)
        {
            
        }
        return ApiResult.Success(_fileHelperService.WalkDirectoryTree(new DirectoryInfo(path)));
    }

    [HttpGet("rename")]
    public ApiResult RenameSingle(string path,string newName)
    {
        var fileInfo = new FileInfo(path);
        if (string.IsNullOrEmpty(fileInfo.DirectoryName)) return ApiResult.Failed("file did not exists");
        var newPath = Path.Combine(fileInfo.DirectoryName, newName);
        _renameService.ExecuteRename(fileInfo,newPath);
        return ApiResult.None("rename success!");
    }

    [HttpGet("replace")]
    public ApiResult Replace(string filePath, string oldStr, string newStr)
    {
        return ApiResult.Success(_renameService.Replace(filePath, oldStr, newStr));
    }

    [HttpGet("replacebyregex")]
    public ApiResult ReplaceByRegex(string filePath, string pattern, string replacement)
    {
        return ApiResult.Success(_renameService.ReplaceByRegex(filePath,pattern,replacement));
    }

    [HttpGet("addtotail")]
    public ApiResult AddStrToTail(string filePath, string str)
    {
        return ApiResult.Success(_renameService.AddStrToTail(filePath,str));
    }

    [HttpGet("delete")]
    public ApiResult DeleteFile(string filePath)
    {
        try
        {
            return ApiResult.None("delete success");

        }
        catch (Exception e)
        {
            _logger.LogError("failed to delete!",e.Message);
            return ApiResult.Failed("failed to delete!");
        }
    }
    
}