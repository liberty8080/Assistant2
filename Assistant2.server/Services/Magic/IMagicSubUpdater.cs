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
            MagicSubscribeType.Songuo => new SonguoUpdater(),
            MagicSubscribeType.StarDream => new RocketUpdater(),
            MagicSubscribeType.Frog =>new SonguoUpdater(),
            _ => throw new MagicException("this subscribe type not supported")
        };
    }

    public static IMagicSubUpdater Updater(MagicSubscribe subscribe)
    {
        return Updater(subscribe.Type);
    }

}