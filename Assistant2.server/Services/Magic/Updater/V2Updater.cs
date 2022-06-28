using Assistant2.Models;
using static Assistant2.Util.MagicUtil;

namespace Assistant2.Services.Magic.Updater;

public class V2Updater : BaseUpdater
{
    public V2Updater(MagicSubscribe subscribe) : base(subscribe)
    {
    }

    public override MagicSubHistory SubInfo()
    {
        if (History.Data == string.Empty)
        {
            FetchData();
        }

        // raw data
        var subData = GetSubData(History.Data);
        var v2Entities = subData.Select(DecodeV2Data).ToArray();
        foreach (var v2Entity in v2Entities)
        {
            Console.WriteLine(v2Entity.ps);
        }
        return History;
    }

    private void ParseBandwidth(V2Entity v2)
    {
    }

    private void ParseExpire(V2Entity v2)
    {
    }
}