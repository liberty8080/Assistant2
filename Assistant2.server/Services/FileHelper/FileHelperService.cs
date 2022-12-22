using System.Collections;
using System.Runtime.InteropServices;
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
        string[] drives;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            drives = GetWinDriveList();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            drives = GetLinuxDriverList();
        }
        else
        {
            drives = Array.Empty<string>();
        }

        var fileInfos = new List<FileInfoDto>();
        foreach (var dr in drives)
        {
            var di = new DriveInfo(dr);
            if (!di.IsReady)
            {
                _logger.LogWarning("The drive {DiName} could not be read", di.Name);
                continue;
            }
            var rootDir = di.RootDirectory.FullName;
            fileInfos.Add(new FileInfoDto(rootDir));
        }

        return fileInfos.ToArray();
    }

    public IEnumerable<FileInfoDto> WalkDirectoryTree(DirectoryInfo root)
    {
        var files = new List<FileInfoDto>();
        try
        {
            files.AddRange(Directory.GetFiles(root.FullName).Select(f => new FileInfoDto(f)));
            files.AddRange(Directory.GetDirectories(root.FullName).Select(f => new FileInfoDto(f)));
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

    private string[] GetWinDriveList()
    {
        return Environment.GetLogicalDrives();
    }

    private string[] GetLinuxDriverList()
    {
        var drivers = Directory.GetDirectories("/");
        string[] ignore =
        {
            "/run", "/sys", "/bin", "/opt", "/boot", "/dev", "/proc", "/usr",
            "/etc", "/sbin", "/var", "/tmp", "/opt", "/srv","/lib"
        };
        return drivers.Where(d => !ignore.Contains(d)).ToArray();
    }
}