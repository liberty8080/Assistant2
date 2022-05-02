using Assistant2.Dao;
using Assistant2.Models;

namespace Assistant2.Services.Magic;

public class MagicSubscribeService
{
    private readonly AssistantDbContext _context;

    public MagicSubscribeService(AssistantDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 拉取订阅信息
    /// </summary>
    /// <param name="id"></param>
    public void UpdateById(int id)
    {
        var sub = _context.MagicSubscribes
            .Single(e => e.Id == id);
        var updater = MagicSubUpdaterFactory.Updater(sub.Type);
        updater.Update(ref sub);
        _context.SaveChanges();
    }

    public IEnumerable<MagicSubscribe> Subscribes()
    {
        return _context.MagicSubscribes.ToArray();
    }

    public void Edit(MagicSubscribe subscribe)
    {
        _context.Update(subscribe);
    }

    public void Remove(MagicSubscribe subscribe)
    {
        _context.Remove(subscribe);
    }
}