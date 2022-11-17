using System;
using System.ComponentModel;
using System.IO;
using Assistant2.Util;
using NUnit.Framework;

namespace TestProject1.Util;

[TestFixture]
public class ByteConvertUtilTest
{
    [TestCase(8819434710,ExpectedResult = "8.21GB")] //GB
    [TestCase(12673081,ExpectedResult = "12.09MB")] //MB
    [TestCase(1024,ExpectedResult = "1.00KB")] //KB
    [TestCase(2048,ExpectedResult = "2.00KB")]
    public string ToStringTest(long length)
    {
        return ByteConvertUtil.ToString(length);
    }
}