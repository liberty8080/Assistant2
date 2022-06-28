using System;
using System.Collections.Generic;
using Assistant2.Models;
using Assistant2.Services.Magic;
using Assistant2.Services.Magic.Updater;
using Assistant2.Util;
using NUnit.Framework;

namespace TestProject1;

[TestFixture]
public class MagicTest
{
    [TestCase("vmess://test", ExpectedResult = true)]
    [TestCase("trojan://test", ExpectedResult = false)]
    [TestCase("ss://test", ExpectedResult = false)]
    [TestCase("vless://test", ExpectedResult = false)]
    public bool V2CheckTest(string input)
    {
        return MagicUtil.CheckV2Format(input);
    }


}