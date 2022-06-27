using System.Buffers.Text;
using System.Text;
using Assistant2.Models;
using Newtonsoft.Json;

namespace Assistant2.Util;

public static class MagicUtil
{
    // v2 decode once
    public static string[] GetSubData(string data)
    {
        // decode 1
        var d1 = Encoding.UTF8.GetString(Convert.FromBase64String(data));
        // sub raw data
        var subRawData = d1.Split("\n");
        
        return subRawData.Where(CheckV2Format).ToArray();
    }

    public static bool CheckV2Format(string data)
    {
        return data.StartsWith("vmess://") || data.StartsWith("torjan");
    }

        // v2 decode twice
        public static V2Entity DecodeV2Data(string data)
    {
        var d = data.Replace("vmess://", "");
        var json = Encoding.UTF8.GetString(Convert.FromBase64String(d));
        var v2 = JsonConvert.DeserializeObject<V2Entity>(json);
        return v2;
    }
}