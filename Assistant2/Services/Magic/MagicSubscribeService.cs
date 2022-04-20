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
    // 更新订阅信息
    public void UpdateAll()
    {
        
    }
    
    public void UpdateById(int id)
    {
        var sub = _context.MagicSubscribes
            .Single(e => e.Id == id);
        var updater = new MagicSubUpdaterFactory(sub.Type).Updater;
        updater.Update(ref sub);
        _context.SaveChanges();
    }
    public void AddSubByUrl(string url, MagicSubscribeType type, string comment)
    {
        
    }
}