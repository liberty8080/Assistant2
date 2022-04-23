using Quartz;
using Quartz.Impl;

namespace Assistant2.Schedule;

public static class MagicJobExtension
{
    //todo: 改成动态的
    public static IServiceCollection AddMagicScheduleJob(this IServiceCollection services)
    {
        var factory = new StdSchedulerFactory();
        var schedule = factory.GetScheduler();
        schedule.Start();
        var job = JobBuilder.Create<MagicSubUpdateJob>().WithIdentity("magicJob").Build();
        var trigger = TriggerBuilder.Create().WithIdentity("magicSubUpdate").WithCronSchedule("0 45 23 * * ?")
            .ForJob("magicJob").Build();
        schedule.Result.ScheduleJob(job, trigger);
        return services;
    }
}