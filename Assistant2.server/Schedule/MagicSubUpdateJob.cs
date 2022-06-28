using Assistant2.Exceptions;
using Assistant2.Services;
using Assistant2.Services.Announce;
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
            _logger.LogInformation("start to update subscribe");
            var subscribes = _service.Subscribes();
            var magicSubscribes = subscribes.ToList();
            if (!magicSubscribes.Any())
            {
                _announce.SendMagic("更新失败，未添加订阅链接", "", 1);
                return;
            }

            foreach (var s in magicSubscribes)
            {
                try
                {
                    _service.UpdateById(s.Id);
                }
                catch (MagicException e)
                {
                    _logger.LogError("magic sub update error! {Ex}", e.ToString());
                    _announce.SendMagic(s.Name, "订阅更新失败！", 1);
                }
            }
        });
    }
}