using System.Collections;

namespace Assistant2.Services.FileHelper;

public class FileHelperService
{
    private readonly ILogger<FileHelperService> _logger;

    public FileHelperService(ILogger<FileHelperService> logger)
    {
        _logger = logger;
    }
  
    public IEnumerable<string> ShowRootFiles()
    {
        var drives = Environment.GetLogicalDrives();
        var fileInfos = new List<string>();
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
    
    public IEnumerable<string> WalkDirectoryTree(DirectoryInfo root)
    {
        var files = new List<string>();
        try
        {
            files.AddRange(Directory.GetFiles(root.FullName));
            files.AddRange(Directory.GetDirectories(root.FullName));
        }
        catch (DirectoryNotFoundException e)
        {
            _logger.LogWarning(e, "Directory ({RootName}) not found!", root.Name);
            throw;
        }

        return files;
    }


}