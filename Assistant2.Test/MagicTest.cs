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
}