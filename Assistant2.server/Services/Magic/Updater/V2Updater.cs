using System.Text.RegularExpressions;
using Assistant2.Models;
using Quartz.Util;
using static Assistant2.Util.MagicUtil;

namespace Assistant2.Services.Magic.Updater;

public class V2Updater : BaseUpdater
{
    public V2Updater(MagicSubscribe subscribe) : base(subscribe)
    {
    }

    private const string BandwidthLeftPattern = @"(\d+\.\d+)\s*([GT]B)";

    private const string ExpireDateTimePattern = @"(\d{4}[/-]\d{1,2}[/-]\d{1,2}( \d{2}:\d{2}:\d{2})?)";

    // private const string 
    public override MagicSubHistory SubInfo()
    {
        if (History.Data == string.Empty)
        {
            FetchData();
        }

        // raw data
        var subData = GetSubData(History.Data);
        var v2Entities = subData.Select(DecodeV2Data).ToArray();
        // History.BandwidthLeft = ParseBandwidth();
        foreach (var en in v2Entities)
        {
            var remark = en.remark.IsNullOrWhiteSpace() ? en.ps : en.remark;
            if (remark.IsNullOrWhiteSpace())
            {
                continue;
            }

            var band = ParseBandwidth(remark);
            if (band > 0)
            {
                History.BandwidthLeft = ParseBandwidth(remark);
                if (History.ExpirationTime != null) break;
            }

            if (!TryParseExpireDateTime(remark, out var dt)) continue;
            History.ExpirationTime = dt;
            if (History.BandwidthLeft > 0) break;


            // History.ExpirationTime = ParseExpireDateTime(remark);
        }

        return History;
    }

    /// <summary>
    /// 解析剩余流量，统一转成GB返回
    /// </summary>
    /// <param name="input">待解析输入</param>
    /// <returns>\d{1-3}+.\d{2}GB</returns>
    public static double ParseBandwidth(string input)
    {
        var groups = Regex.Match(input, BandwidthLeftPattern).Groups;
        var bs = groups[1].Value;
        if (bs == "") return 0;
        var bandwidth = double.Parse(bs);
        if (groups[2].Value.Equals("TB"))
        {
            bandwidth *= 1024;
        }

        return bandwidth;
    }

    public static bool TryParseExpireDateTime(string input, out DateTime dt)
    {
        dt = DateTime.MinValue;
        var groups = Regex.Match(input, ExpireDateTimePattern).Groups;
        var date = groups[1].Value;
        return DateTime.TryParse(date, out dt);
    }
}