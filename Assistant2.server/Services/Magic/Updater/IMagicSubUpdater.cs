using Assistant2.Exceptions;
using Assistant2.Models;

namespace Assistant2.Services.Magic.Updater;

public interface IMagicSubUpdater
{
    public MagicSubHistory SubInfo();
}

public  class MagicSubUpdaterFactory
{
    public IEnumerable<IMagicSubUpdater> Updaters { get; }
    private readonly ILogger<MagicSubUpdaterFactory> _logger;

    public MagicSubUpdaterFactory(IEnumerable<IMagicSubUpdater> updaters,ILogger<MagicSubUpdaterFactory> logger)
    {
        Updaters = updaters;
        _logger = logger;
    }
    public  IMagicSubUpdater Updater(MagicSubscribe magic)
    {
        return magic.Type switch
        {
            MagicSubscribeType.V2 => new V2Updater(magic),
            MagicSubscribeType.Rocket => new RocketUpdater(magic),
            _ => throw new MagicException("this subscribe type not supported")
        };
        foreach (var up in Updaters)
        {
            
        }
    }

    /*public static IMagicSubUpdater Updater(MagicSubscribe subscribe)
    {
        return Updater(subscribe.Type);
    }*/
}

public abstract class BaseUpdater : IMagicSubUpdater
{
    
    protected BaseUpdater(MagicSubscribe subscribe,ILogger<BaseUpdater> logger)
    {
        Subscribe = subscribe;
        History = new MagicSubHistory
        {
            SubId = subscribe.Id,
            UpdateTime = DateTime.Now
        };
        _logger = logger;
    }

    private readonly ILogger<BaseUpdater> _logger;
    protected MagicSubscribe Subscribe { get; }
    protected MagicSubHistory History { get; }

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