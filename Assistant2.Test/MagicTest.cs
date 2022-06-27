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
        var songuo = new SonguoUpdater();
        var sub = new MagicSubscribe
        {
            Url = "https://subd5ow.v6746.top/link/kyPH1D1TW2hE5tu5?sub=3"
        };
        songuo.Update(ref sub);
        Console.WriteLine(sub);
    }
}