using Assistant2.Util;
using Microsoft.VisualBasic;

namespace Assistant2.Models;

public class FileInfoDto
{
    public FileInfoDto(string filePath)
    {
        FilePath = filePath;
        
        if (File.Exists(filePath))
        {
            IsDirectory = false;
            var fileInfo = new FileInfo(filePath);
            Length = fileInfo.Length;
        }else if (Directory.Exists(filePath))
        {
            IsDirectory = true;
        }
        
        
        // if directory
        IsDirectory = Directory.Exists(filePath);
        
        Parent = Path.GetDirectoryName(filePath);

    }

    public FileInfoDto(string filePath, string newName) : this(filePath)
    {
        NewName = newName;
    }

    public bool IsDirectory { get; }
    public string FilePath { get; }
    public string OldName => Path.GetFileName(FilePath);

    public string? Parent { get; }

    public string? NewName { get; set; }
    public string? NewFullName => string.IsNullOrEmpty(NewName) ? null : Parent + NewName;

    public long Length { get; }
    public string FileSize => ByteConvertUtil.ToString(Length);
}