namespace Assistant2.Util;

public class ConvertUtil
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
}