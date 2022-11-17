namespace Assistant2.Util;

public static class ByteConvertUtil
{
    /// <summary>
    /// mb,tb to gb
    /// </summary>
    /// <param name="data">11.22TB</param>
    /// <returns>xx.xxGB</returns>
    public static double AnyToGb(string data)
    {
        data = data.ToUpper();
        if (data.EndsWith("GB"))
        {
            return double.Parse(data.Replace("GB", ""));
        }

        if (data.EndsWith("TB"))
        {
            return double.Parse(data.Replace("TB", "")) / 1024;
        }

        if (data.EndsWith("MB"))
        {
            return double.Parse(data.Replace("MB", "")) * 1024;
        }

        throw new Exception("not supported");
    }

    /// <summary>
    /// byte to string, like xxMB xxGB xxTB
    /// </summary>
    /// <param name="data">byte</param>
    /// <returns></returns>
    public static string ToString(long data)
    {
        //GB
        if (data.CompareTo(1024 * 1024 * 1024) >= 0)
        {
            return $"{(double)data / (1024 * 1024 * 1024):F}GB";
        }

        //MB
        if (data.CompareTo(1024 * 1024) >= 0)
        {
            return $"{(double)data / (1024 * 1024):F}MB";
        }

        //KB
        if (data.CompareTo(1024) >= 0)
        {
            return $"{(double)data / 1024:F}KB";
        }

        return data + "B";
    }
}