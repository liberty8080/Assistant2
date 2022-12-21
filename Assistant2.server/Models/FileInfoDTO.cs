using Assistant2.Util;

namespace Assistant2.Models;

public class FileInfoDto
{

    public FileInfoDto(string filePath)
    {
        FilePath = filePath;
        if (File.Exists(filePath))
        {
            var fileInfo = new FileInfo(filePath);
            Length = fileInfo.Length;
        }
        DirectoryName = Path.GetDirectoryName(filePath);
        
    }
    
    public FileInfoDto(string filePath,string newName):this(filePath)
    {
        NewName = newName;
    }

    public string FilePath { get; }
    public string OldName => Path.GetFileName(FilePath);
    
    public string? DirectoryName { get; }
    public string? NewName { get; set; }
    public string? NewFullName => DirectoryName + NewName;

    public long Length { get; }
    public string FileSize => ByteConvertUtil.ToString(Length);
}