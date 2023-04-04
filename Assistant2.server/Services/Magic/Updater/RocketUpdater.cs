using System.Text.RegularExpressions;
using Assistant2.Exceptions;
using Assistant2.Models;
using Assistant2.Util;

namespace Assistant2.Services.Magic.Updater;

public class RocketUpdater : BaseUpdater
{
    public RocketUpdater(MagicSubscribe subscribe,
        ILogger<RocketUpdater> logger) : base(subscribe,logger)
    {
    }

    private const string Reg = @"^STATUS=(.*)\n";
    private const string DefaultPattern = @"\D*(?<bandwidth>\d+\.\d+[MGT]B)\D*(?<expire>\d{4}[-.]\d{2}[-.]\d{2})";

    public override MagicSubHistory SubInfo()
    {
        if (History.Data == string.Empty)
        {
            FetchData();
        }

        var rowData = MagicUtil.DecodeBase64(History.Data);
        var matches = Regex.Match(rowData, Reg);
        var status = matches.Groups[1].Value.Trim();
        ParseInfo(status);
        return History;
    }

    // parse expire time and flow 
    public void ParseInfo(string target)
    {
        var pattern = Subscribe.RocketRegex != string.Empty ? Subscribe.RocketRegex : DefaultPattern;
        var m = Regex.Match(target, pattern);
        if (!m.Groups[1].Success || !m.Groups[2].Success)
        {
            throw new MagicException($"sub info parse failed! original string is:{target}" +
                                     "use named regex: [bandwidth,expire]");
        }

        History.BandwidthLeft = ByteConvertUtil.AnyToGb(m.Groups["bandwidth"].Value);
        History.ExpirationTime = DateTime.Parse(m.Groups["expire"].Value);
    }
}