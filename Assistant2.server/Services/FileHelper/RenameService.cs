using System.Text.RegularExpressions;
using Assistant2.Exceptions;
using Assistant2.Models;

namespace Assistant2.Services.FileHelper;

public class RenameService
{
    private readonly ILogger<RenameService> _logger;

    public RenameService(ILogger<RenameService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// rename single file
    /// </summary>
    public void ExecuteRename(FileInfo file, string newPath)
    {
        var d = file.DirectoryName;
        if (d == null) return;
        file.MoveTo(Path.Combine(d, newPath));
    }


    public RenameFileInfo Replace(string filePath, string oldStr, string newStr)
    {
        var d = Path.GetDirectoryName(filePath);
        if (d == null) throw new FileHelperException("filename replace failed,no directory name!");
        var newName = Path.GetFileName(filePath).Replace(oldStr, newStr);
        return new RenameFileInfo(filePath, newName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filePath">example: Test.01.txt</param>
    /// <param name="pattern">example: "(.)(01)(.)"</param>
    /// <param name="replacement">example: $1S01E$2$3</param>
    /// <returns>.S01E01.</returns>
    public RenameFileInfo ReplaceByRegex(string filePath, string pattern, string replacement)
    {
        var newName = Regex.Replace(Path.GetFileName(filePath), pattern, replacement);
        return new RenameFileInfo(filePath, newName);
    }

    // 文件名后加字符串
    public RenameFileInfo AddStrToTail(string filePath, string str)
    {
        var name = Path.GetFileNameWithoutExtension(filePath);
        name += str;
        name += Path.GetExtension(filePath);
        return new RenameFileInfo(filePath, name);
    }
}