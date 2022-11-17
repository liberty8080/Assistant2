using Assistant2.Util;

namespace Assistant2.Models;

public class RenameFileInfo
{

    public RenameFileInfo(string filePath,string newName)
    {
        // FullName = fileInfo.FullName;
        FilePath = filePath;
        if (File.Exists(filePath))
        {
            var fileInfo = new FileInfo(filePath);
            Length = fileInfo.Length;
        }
        // if (fileInfo.DirectoryName != null) DirectoryName = fileInfo.DirectoryName;
        DirectoryName = Path.GetDirectoryName(filePath);
        NewName = newName;
    }

    public string FilePath { get; }
    public string OldName => Path.GetFileName(FilePath);
    
    public string? DirectoryName { get; }
    public string NewName { get; set; }
    public string NewFullName => DirectoryName + NewName;

    public long Length { get; }
    public string FileSize => ByteConvertUtil.ToString(Length);
}