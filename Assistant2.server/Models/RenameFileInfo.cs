using System.ComponentModel;
using Assistant2.Util;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assistant2.Models;

public class RenameFileInfo
{
    public RenameFileInfo(FileInfo fileInfo)
    {
        FullName = fileInfo.FullName;
        Length = fileInfo.Length;
    }

    public string FullName { get; }
    public string Name => Path.GetFileName(FullName);

    public string NewName => Path.GetFileName(NewFullName);
    public string NewFullName { get; set; }
    
    public long Length { get; set; }

    public string FileSize()
    {
        throw new NotImplementedException();
    }
}