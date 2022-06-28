using System.Text.RegularExpressions;
using Assistant2.Models;
using Assistant2.Util;

namespace Assistant2.Services.Magic;

public class RocketUpdater : BaseUpdater
{

    private readonly string _reg = @"^STATUS=(.*)\nREMARKS=(.*)\n";
    public override void Update(ref MagicSubscribe subscribe)
    {
        if (subscribe.Data != string.Empty)
        {
            var rowData = MagicUtil.GetSubData(subscribe.Data);
            // var matches = Regex.Matches(rowData, _reg);
        }
    }
}