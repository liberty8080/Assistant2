using Assistant2.Services.Magic;
using Quartz;
using Quartz.Impl;

namespace Assistant2.Schedule;

public static class MagicJobExtension
{
    //todo: 改成动态的
    public static IServiceCollection AddMagicScheduleJob(this IServiceCollection services)
    {
        services.AddScoped<MagicSubUpdateJob>();
        services.AddScoped<MagicSubscribeService>();

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            q.ScheduleJob<MagicSubUpdateJob>(trigger =>
                {
                    trigger.WithIdentity("magicSubUpdate")
                        .WithCronSchedule("0 45 23 * * ?")
                        .ForJob("magicJob");
                }
            );
        }
           );
        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });


        return services;
    }
}