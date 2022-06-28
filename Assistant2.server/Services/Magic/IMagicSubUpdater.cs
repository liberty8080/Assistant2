using Assistant2.Exceptions;
using Assistant2.Models;

namespace Assistant2.Services.Magic;

public interface IMagicSubUpdater
{
    public void Update(ref MagicSubscribe subscribe);
}

public static class MagicSubUpdaterFactory
{
    public static IMagicSubUpdater Updater(MagicSubscribeType type)
    {
        return type switch
        {
            MagicSubscribeType.V2 => new V2Updater(),
            MagicSubscribeType.StarDream => new RocketUpdater(),
            MagicSubscribeType.Frog => new V2Updater(),
            _ => throw new MagicException("this subscribe type not supported")
        };
    }

    public static IMagicSubUpdater Updater(MagicSubscribe subscribe)
    {
        return Updater(subscribe.Type);
    }
}

public abstract class BaseUpdater : IMagicSubUpdater
{
    public void FetchData(ref MagicSubscribe subscribe)
    {
        if (subscribe.Url == string.Empty) return;
        var client = new HttpClient();
        var rowData = client.GetStringAsync(subscribe.Url).Result;
        subscribe.Data = rowData;
    }

    public abstract void Update(ref MagicSubscribe subscribe);
}