using System.Threading.Tasks;
using Hangfire;
using WillEnergy.WebUI.Jobs.Common;

namespace WillEnergy.WebUI.Jobs
{
    public class SampleSchedulerJob : IJob
    {
        private static readonly string Frequency = Cron.Hourly();
        // private readonly IMediator _bus;

        // public SampleSchedulerJob(IMediator bus)
        // {
            // _bus = bus;
        // }

        public static void Schedule()
        {
            // RecurringJob.RemoveIfExists(nameof(SampleSchedulerJob));
            // RecurringJob.AddOrUpdate<SampleSchedulerJob>(
            //     nameof(SampleSchedulerJob),
            //     job => job.Execute(), Frequency);
        }

        public Task Execute()
        {
            // await _bus.Send(new TestCommand());
            return Task.CompletedTask;
        }
    }
}
