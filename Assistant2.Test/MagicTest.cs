using System;
using System.Collections.Generic;
using Assistant2.Models;
using Assistant2.Services.Magic;
using NUnit.Framework;

namespace TestProject1;

[TestFixture]
public class MagicTest
{
    [Test]
    public void SubInfoTest()
    {
        var songuo = new V2Updater();
        var sub = new MagicSubscribe
        {
            Url = ""
        };
        songuo.Update(ref sub);
        Console.WriteLine(sub);
    }

    [Test]
    public void ParseTest()
    {
        const string status = "剩余流量：9.72TB.♥.2022-07-05";
        var s = new MagicSubscribe
        {
            RocketRegex = @"剩余流量：(?<bandwidth>\d\.\d{2}(GB|TB|MB)).♥.(?<expire>\d{4}-\d{2}-\d{2})"
        };
        RocketUpdater.ParseInfo(ref s,status);
        Console.WriteLine(s.BandwidthLeft);
        Console.WriteLine(s.ExpirationTime);
    }
}