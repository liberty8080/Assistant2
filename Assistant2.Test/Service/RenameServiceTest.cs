using System.IO;
using Assistant2.Services.FileHelper;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestProject1.Service;

[TestFixture]
public class RenameServiceTest
{
    private readonly RenameService _service;

    public RenameServiceTest()
    {
        var logger = Mock.Of<ILogger<RenameService>>();
        _service = new RenameService(logger);
    }

    [Test]
    public void ReplaceTest()
    {
        var renameFileInfo = _service.Replace("/mnt/Test.txt", "Test", "new");
        Assert.AreEqual( "new.txt",renameFileInfo.NewName);
    }

    [Test]
    public void ReplaceRegexTest()
    {
        var renameFileInfo = _service.ReplaceByRegex("/mnt/Test.01.txt", @"(\.)(\d{2,3})(\.)", "$1S01E$2$3");
        Assert.AreEqual("Test.S01E01.txt",renameFileInfo.NewName);
    }

    [Test]
    public void AddToTailTest()
    {
        var renameFileInfo = _service.AddStrToTail("/mnt/Test.srt",".cn");
        Assert.AreEqual("Test.cn.srt",renameFileInfo.NewName);
    }
}