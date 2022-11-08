using System;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace TestProject1.Service;

using Assistant2.Services.FileHelper;

[TestFixture]
public class FileHelperTest
{
    [Test]
    public void ShowRootFilesTest()
    {
        var logger = Mock.Of<ILogger<FileHelperService>>();
        var fileHelperService = new FileHelperService(logger);
        var fileInfos = fileHelperService.ShowRootFiles();
        try
        {
            foreach (var fileInfo in fileInfos)
            {
                Console.WriteLine(fileInfo);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Assert.Fail();
            throw;
        }
        
    }
}