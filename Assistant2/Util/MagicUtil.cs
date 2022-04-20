using System.Buffers.Text;

namespace Assistant2.Util;

public static class MagicUtil
{
    public static byte[] GetData(string url)
    {
        var client = new HttpClient();
        var content = client.GetAsync(url).Result.Content
            .ReadAsStringAsync().Result;
        var d1 = Convert.FromBase64String(content);

        return null;
    }
    
    public static void Decode(string data)
    {
    }
}