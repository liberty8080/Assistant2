using System.Text.RegularExpressions;

namespace Assistant2.Services.FileHelper;

public class RenameService
{
    /// <summary>
    /// rename single file
    /// </summary>
    public void ExecuteRename(FileInfo file, string newPath)
    {
        var d = file.DirectoryName;
        if (d == null) return;
        file.MoveTo(Path.Combine(d, newPath));
    }

    
    public void Replace(FileInfo file, string oldStr, string newStr)
    {
        var d = file.DirectoryName;
        if (d == null) return;
        var newName = file.Name.Replace(oldStr, newStr);
        file.MoveTo(Path.Combine(d, newName));
    }

    public void ReplaceByRegex(FileInfo file,string oldStr,string newStr)
    {
        Regex.Replace(file.Name, oldStr, newStr);
    }

    public void AddStrToTail(FileInfo fileInfo, string str)
    {
        //name without 
        var name = fileInfo.Name.Split(".")[-1];
        name += str;
        
    }
}