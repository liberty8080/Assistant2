using System;
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
    public void ParseInfoTest(string t)
    {
        var sub = new MagicSubscribe();
        var rocket = new RocketUpdater(sub);
        rocket.ParseInfo(t);
        Console.WriteLine(sub.BandwidthLeft);
        Console.WriteLine(sub.ExpirationTime);
        Assert.IsNotEmpty(sub.BandwidthLeft);
        Assert.IsNotEmpty(sub.ExpirationTime);
    }
}