using Assistant2.Models;

namespace Assistant2.Services.Magic;

public interface IMagicSubUpdater
{
    public void Update(ref MagicSubscribe subscribe);
}

public class MagicSubUpdaterFactory
{
    public IMagicSubUpdater Updater { get; set; }

    public MagicSubUpdaterFactory(MagicSubscribeType type)
    {
        Updater = type switch
        {
            MagicSubscribeType.V2 => new V2Updater(),
            MagicSubscribeType.Rocket => new RocketUpdater(),
            MagicSubscribeType.Clash => new ClashUpdater(),
            _ => throw new Exception("")
        };
    }

}