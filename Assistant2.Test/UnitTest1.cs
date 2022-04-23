using System;
using Assistant2.Models;
using Assistant2.Services.Magic;
using Assistant2.Util;
using NUnit.Framework;

namespace TestProject1;

public class Tests
{
    private const string Url = "https://test";
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {
        
        var result = MagicUtil.GetSubData(Url);
        Console.WriteLine(result);
        Assert.Pass();
    }

    [Test]
    public void TestUpdater()
    {
        MagicSubscribe subscribe = new()
        {
            Type = MagicSubscribeType.Songuo,
            Url = Url,
        };
        var updater =MagicSubUpdaterFactory.Updater(subscribe);
        updater.Update(ref subscribe);
        Console.WriteLine(updater.ToString());
    }
}