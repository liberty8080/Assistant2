using Assistant2.Exceptions;
using Assistant2.Models;

namespace Assistant2.Services.Magic;

public interface IMagicSubUpdater
{
    public void UpdateSubInfo();
}

public static class MagicSubUpdaterFactory
{
    public static IMagicSubUpdater Updater(MagicSubscribe magic)
    {
        return magic.Type switch
        {
            MagicSubscribeType.V2 => new V2Updater(magic),
            MagicSubscribeType.StarDream => new RocketUpdater(magic),
            MagicSubscribeType.Frog => new V2Updater(magic),
            _ => throw new MagicException("this subscribe type not supported")
        };
    }

    /*public static IMagicSubUpdater Updater(MagicSubscribe subscribe)
    {
        return Updater(subscribe.Type);
    }*/
}

public abstract class BaseUpdater : IMagicSubUpdater
{
    protected BaseUpdater(MagicSubscribe subscribe)
    {
        Subscribe = subscribe;
    }

    protected MagicSubscribe Subscribe { get; set; }
    protected void FetchData()
    {
        if (Subscribe.Url == string.Empty) return;
        var client = new HttpClient();
        var rowData = client.GetStringAsync(Subscribe.Url).Result;
        Subscribe.Data = rowData;
    }

    public abstract void UpdateSubInfo();
}