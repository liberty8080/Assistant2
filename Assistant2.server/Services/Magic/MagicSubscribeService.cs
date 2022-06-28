using Assistant2.Dao;
using Assistant2.Models;
using Assistant2.Services.Magic.Updater;

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
        var updater = MagicSubUpdaterFactory.Updater(sub);
        updater.SubInfo();
        _context.SaveChanges();
    }

    public IEnumerable<MagicSubscribe> Subscribes()
    {
        return _context.MagicSubscribes.ToArray();
    }

    public void Edit(MagicSubscribe subscribe)
    {
        // insert or update, dynamic
        _context.Update(subscribe);
        _context.SaveChanges();
    }

    public void Remove(int id)
    {
        _context.Remove(new MagicSubscribe {Id = id});
        _context.SaveChanges();
    }

    public void Add(MagicSubscribe subscribe)
    {
        _context.Add(subscribe);
        _context.SaveChanges();
    }
}