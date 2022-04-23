using Assistant2.Exceptions;
using Assistant2.Services;
using Assistant2.Services.Magic;
using Quartz;

namespace Assistant2.Schedule;

public class MagicSubUpdateJob : IJob
{
    private readonly MagicSubscribeService _service;
    private readonly IAnnounceService _announce;
    private readonly ILogger<MagicSubUpdateJob> _logger;

    public MagicSubUpdateJob(MagicSubscribeService service,
        IAnnounceService announce
        , ILogger<MagicSubUpdateJob> logger)
    {
        _service = service;
        _announce = announce;
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        return Task.Run(() =>
        {
            var subscribes = _service.Subscribes();
            foreach (var s in subscribes)
            {
                try
                {
                    _service.UpdateById(s.Id);
                }
                catch (MagicException e)
                {
                    _logger.LogError("magic sub update error! {Ex}", e.ToString());
                    _announce.SendMagic(s.Comment,"订阅更新失败！",1);
                }
            }
        });
    }
}