using System;
using Assistant2.Services.Magic.Updater;
using NUnit.Framework;

namespace TestProject1.Magic;

[TestFixture]
public class V2UpdaterTest
{
    [TestCase("剩余流量：644.87GB")]
    [TestCase("剩余流量：1.00TB")]
    [TestCase("剩余流量：291.08 GB")]
    public void ParseInfoTest(string input)
    {
        var bandwidth = V2Updater.ParseBandwidth(input);
        Console.WriteLine(bandwidth);
    }

    [TestCase("xxx: 2022-09-01")]
    [TestCase("yyy: 2022/9/1 12:00:00")]
    public void TryParseDateTest(string input)
    {
        var b = V2Updater.TryParseExpireDateTime(input, out var dt);
        Console.WriteLine(dt);
        Assert.True(b);
    }
}