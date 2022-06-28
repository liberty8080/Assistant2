using System.Text.RegularExpressions;
using Assistant2.Exceptions;
using Assistant2.Models;
using Assistant2.Util;

namespace Assistant2.Services.Magic;

public class RocketUpdater : BaseUpdater
{
    private const string Reg = @"^STATUS=(.*)\nREMARKS=.*\n";

    public override void Update(ref MagicSubscribe subscribe)
    {
        if (subscribe.Data != string.Empty)
        {
            var rowData = MagicUtil.DecodeBase64(subscribe.Data);
            var matches = Regex.Match(rowData, Reg);
            var status = matches.Groups[1].Value;
            // var remarks = matches.Groups[2].Value;
        }
        else
        {
        }
    }

    // parse expire time and flow 
    public static void ParseInfo(ref MagicSubscribe subscribe, string target)
    {
        var m = Regex.Match(target, subscribe.RocketRegex);
        if (!m.Groups[1].Success || !m.Groups[2].Success)
        {
            throw new MagicException($"sub info parse failed! original string is:{target}" +
                                     "use named regex: [bandwidth,expire]");
        }
        subscribe.BandwidthLeft = m.Groups["bandwidth"].Value;
        subscribe.ExpirationTime = m.Groups["expire"].Value;
    }
}