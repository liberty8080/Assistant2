using System.Text.RegularExpressions;
using Assistant2.Models;
using Assistant2.Util;

namespace Assistant2.Services.Magic;

public class RocketUpdater : BaseUpdater
{
    private readonly string _reg = @"^STATUS=(.*)\nREMARKS=.*\n";
    
    public override void Update(ref MagicSubscribe subscribe)
    {
        if (subscribe.Data != string.Empty)
        {
            var rowData = MagicUtil.DecodeBase64(subscribe.Data);
            var matches = Regex.Match(rowData, _reg);
            var status = matches.Groups[1].Value;
            // var remarks = matches.Groups[2].Value;
        }
        else
        {
        }
    }

    // parse expire time and flow 
    private static void ParseInfo(ref MagicSubscribe subscribe,string target)
    {
        var m =Regex.Match(target, subscribe.RocketRegex);
        if (!m.Groups[1].Success||!m.Groups[2].Success)
        {
            
        }

    }
}