using Assistant2.Exceptions;
using Assistant2.Models;
using static Assistant2.Util.MagicUtil;

namespace Assistant2.Services.Magic;

public class V2Updater : BaseUpdater
{
    public V2Updater(MagicSubscribe subscribe) : base(subscribe)
    {
    }
    public override void UpdateSubInfo()
    {
        
        if (Subscribe.Url == string.Empty)
        {
            throw new MagicException("url can not be null");
        }
        var client = new HttpClient();
        var res =  client.GetStringAsync(Subscribe.Url).Result;
       Subscribe.Data = res;
        // raw data
        var subData = GetSubData(res);
        // var bandwidthLeft = DecodeV2Data(subData[0]);
        // var expireTime = DecodeV2Data(subData[1]);
        var v2Entities = subData.Select(DecodeV2Data).ToArray();
        Console.WriteLine(v2Entities);
        /*if (bandwidthLeft.remark != "")
        {
            subscribe.BandwidthLeft = bandwidthLeft.remark;
            subscribe.ExpirationTime = expireTime.remark;
        }else if (bandwidthLeft.ps != "")
        {
            subscribe.BandwidthLeft = bandwidthLeft.ps;
            subscribe.ExpirationTime = expireTime.ps;
        }
        else
        {
            throw new MagicException("failed to get subscribe information");
        }*/
        
    }

  
}