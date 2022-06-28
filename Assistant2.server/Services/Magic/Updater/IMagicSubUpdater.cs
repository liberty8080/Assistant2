using Assistant2.Exceptions;
using Assistant2.Models;

namespace Assistant2.Services.Magic.Updater;

public interface IMagicSubUpdater
{
    public MagicSubHistory SubInfo();
}

public static class MagicSubUpdaterFactory
{
    public static IMagicSubUpdater Updater(MagicSubscribe magic)
    {
        return magic.Type switch
        {
            MagicSubscribeType.V2 => new V2Updater(magic),
            MagicSubscribeType.Rocket => new RocketUpdater(magic),
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
    protected MagicSubHistory History { get; set; }

    protected void FetchData()
    {
        if (Subscribe.Url == string.Empty)
        {
            throw new MagicException("subscribe url should not be empty!");
        }

        var client = new HttpClient();
        History.Data = client.GetStringAsync(Subscribe.Url).Result;
    }

    public abstract MagicSubHistory SubInfo();
}