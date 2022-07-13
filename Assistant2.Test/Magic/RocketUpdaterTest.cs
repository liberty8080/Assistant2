using System;
using System.Text.RegularExpressions;
using Assistant2.Models;
using Assistant2.Services.Magic;
using Assistant2.Services.Magic.Updater;
using NUnit.Framework;

namespace TestProject1.Magic;

[TestFixture]
public class RocketUpdaterTest
{
    [TestCase("剩余流量：988.7888GB.♥.2022-07-05")]
    [TestCase("9.7MB.♥.1234-07-05")]
    [TestCase("🚀↑:1.27GB,↓:89.64GB,TOT:400GB💡Expires:2023-02-27")]//bixin
    public void ParseInfoTest(string t)
    {
        var sub = new MagicSubscribe();
        sub.RocketRegex = "";
        var rocket = new RocketUpdater(sub);
        rocket.ParseInfo(t);
        // Console.WriteLine(rocket.BandwidthLeft);
        // Console.WriteLine(sub.ExpirationTime);
        // Assert.IsNotEmpty(sub.BandwidthLeft);
        // Assert.IsNotEmpty(sub.ExpirationTime);
    }

    [Test]
    public void SubHistoryTest()
    {
        var sub = new MagicSubscribe();
    }

    [TestCase("STATUS=🚀↑:1.27GB,↓:89.63GB,TOT:400GB💡Expires:2023-02-27\nxxxxxx")]
    [TestCase("STATUS=🚀↑:1.27GB,↓:89.63GB,TOT:400GB💡Expires:2023-02-27\r\nxxxxxx")]
    public void StatusMatchTest(string rowData)
    {
        // var rowData = "STATUS=🚀↑:1.27GB,↓:89.63GB,TOT:400GB💡Expires:2023-02-27\nxxxxxx";
        const string reg = @"^STATUS=(.*)\n";
        var s = Regex.Match(rowData, reg);
        var status = s.Groups[1].Value.Trim();
        Console.Write("status:"+status);
        Assert.AreEqual("🚀↑:1.27GB,↓:89.63GB,TOT:400GB💡Expires:2023-02-27",status);
    }
}