using System.Collections;
using Assistant2.Models;

namespace Assistant2.Services.FileHelper;

public class FileHelperService
{
    private readonly ILogger<FileHelperService> _logger;

    public FileHelperService(ILogger<FileHelperService> logger)
    {
        _logger = logger;
    }
  
    public IEnumerable<FileInfoDto> ShowRootFiles()
    {
        
        //todo: win or linux
        var drives = Environment.GetLogicalDrives();
        var fileInfos = new List<FileInfoDto>();
        foreach (var dr in drives)
        {
            var di = new DriveInfo(dr);
            if (!di.IsReady)
            {
                _logger.LogWarning("The drive {DiName} could not be read", di.Name);
                continue;
            }
            var rootDir = di.RootDirectory;
            fileInfos.AddRange(WalkDirectoryTree(rootDir));
        }
        return fileInfos.ToArray();
    }
    
    public IEnumerable<FileInfoDto> WalkDirectoryTree(DirectoryInfo root)
    {
        var files = new List<FileInfoDto>();
        try
        {
            
            files.AddRange(Directory.GetFiles(root.FullName).Select(f=>new FileInfoDto(f)));
            files.AddRange(Directory.GetDirectories(root.FullName).Select(f=>new FileInfoDto(f)));
        }
        catch (UnauthorizedAccessException e)
        {
            _logger.LogWarning(e, "Permission denied! path:{pah}", root.FullName);
        }
        catch (DirectoryNotFoundException e)
        {
            _logger.LogWarning(e, "Directory ({RootName}) not found!", root.Name);
            throw;
        }

        return files;
    }


}