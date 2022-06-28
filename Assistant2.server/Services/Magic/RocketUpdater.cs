using System.Text.RegularExpressions;
using Assistant2.Exceptions;
using Assistant2.Models;
using Assistant2.Util;

namespace Assistant2.Services.Magic;

public class RocketUpdater : BaseUpdater
{
    public RocketUpdater(MagicSubscribe subscribe) : base(subscribe)
    {
    }
    private const string Reg = @"^STATUS=(.*)\nREMARKS=.*\n";

    public override void UpdateSubInfo()
    {
        if (Subscribe.Data == string.Empty)
        {
            FetchData();
        }
        ParseInfo();
    }

    // parse expire time and flow 
    public void ParseInfo()
    {
        var rowData = MagicUtil.DecodeBase64(Subscribe.Data);
        var matches = Regex.Match(rowData, Reg);
        var status = matches.Groups[1].Value;
        var m = Regex.Match(status, Subscribe.RocketRegex);
        if (!m.Groups[1].Success || !m.Groups[2].Success)
        {
            throw new MagicException($"sub info parse failed! original string is:{status}" +
                                     "use named regex: [bandwidth,expire]");
        }
        Subscribe.BandwidthLeft = m.Groups["bandwidth"].Value;
        Subscribe.ExpirationTime = m.Groups["expire"].Value;
    }


}