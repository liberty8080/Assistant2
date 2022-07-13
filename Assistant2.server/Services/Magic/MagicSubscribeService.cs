using Assistant2.Dao;
using Assistant2.Models;
using Assistant2.Services.Magic.Updater;
using Microsoft.EntityFrameworkCore;

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
        var history = updater.SubInfo();
        _context.Add(history);
        _context.SaveChanges();
    }

    public IEnumerable<MagicSubDto> Subscribes()
    {
        var dto = from sub in _context.MagicSubscribes
            let history = _context.MagicSubHistories.Where(h=>h.SubId==sub.Id)
                .OrderByDescending(h=>h.Id).First()
            select new MagicSubDto(sub, history);

        return dto.ToArray();
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