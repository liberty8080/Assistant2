using System.Text.RegularExpressions;

namespace Assistant2.Services.FileHelper;

public class DeleteService
{
    private readonly ILogger<DeleteService> _logger;

    public DeleteService(ILogger<DeleteService> logger)
    {
        _logger = logger;
    }


    /// <summary>
    /// 执行删除,单个文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    public void ExecuteDelete(string filePath)
    {
        try
        {
            var file = new FileInfo(filePath);
            file.Delete();
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "删除失败！");
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="files"></param>
    public void ExecuteDelete(IEnumerable<string> files)
    {
        foreach (var file in files)
        {
            try
            {
                var fileInfo = new FileInfo(file);
                fileInfo.Delete();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "删除失败！");
                throw;
            }
        }
    }

    /// <summary>
    /// If file is match
    /// </summary>
    /// <param name="fileInfo">文件</param>
    /// <param name="fileSize">文件大小(字节)，小于则匹配</param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public bool FileIsMatch(FileInfo fileInfo, long? fileSize, string? pattern)
    {
        var result = true;
        
        // 小于指定的文件大小才会命中
        if (fileSize.HasValue)
        {
            if (fileInfo.Length > fileSize)
            {
                result = false;
            }
        }

        if (pattern != null)
        {
            if (!Regex.IsMatch(fileInfo.Name, pattern))
            {
                result = false;
            }
        }

        return result;
    }
}