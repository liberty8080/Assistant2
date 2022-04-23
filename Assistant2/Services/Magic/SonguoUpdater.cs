using Assistant2.Exceptions;
using Assistant2.Models;
using static Assistant2.Util.MagicUtil;

namespace Assistant2.Services.Magic;

public class SonguoUpdater : IMagicSubUpdater
{
    public void Update(ref MagicSubscribe subscribe)
    {
        if (subscribe.Url == string.Empty)
        {
            throw new MagicException("url can not be null");
        }
        var client = new HttpClient();
        var res =  client.GetAsync(subscribe.Url).Result
            .Content.ReadAsStringAsync().Result;
        subscribe.Data = res;
        // raw data
        var subData = GetSubData(res);
        var bandwidthLeft = DecodeV2Data(subData[0]);
        var expireTime = DecodeV2Data(subData[1]);

        if (bandwidthLeft.remark != "")
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
        }
        
    }
}