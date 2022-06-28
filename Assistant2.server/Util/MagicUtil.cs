using System.Buffers.Text;
using System.Text;
using System.Text.RegularExpressions;
using Assistant2.Models;
using Newtonsoft.Json;

namespace Assistant2.Util;

public static class MagicUtil
{
    public static string DecodeBase64(string data)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(data));
    }

    // v2 decode once
    public static IEnumerable<string> GetSubData(string data)
    {
        // decode 1
        var d1 = DecodeBase64(data);
        // sub raw data
        var subRawData = d1.Split("\n");
        return subRawData.Where(CheckV2Format).ToArray();
    }

    // v2 decode twice
    public static V2Entity DecodeV2Data(string data)
    {
        var d = data.Replace("vmess://", "");
        var json = Encoding.UTF8.GetString(Convert.FromBase64String(d));
        var v2 = JsonConvert.DeserializeObject<V2Entity>(json);
        return v2;
    }

    public static bool CheckV2Format(string data)
    {
        // const string pattern = @"^(?:vmess|trojan|ss)";
        // 暂只支持vmess
        const string pattern = @"^(?:vmess)://";
        return Regex.IsMatch(data, pattern);
        // return data.StartsWith("vmess://") || data.StartsWith("torjan");
    }
}