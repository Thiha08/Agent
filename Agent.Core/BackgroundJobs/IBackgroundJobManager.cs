using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Core.BackgroundJobs
{
    public interface IBackgroundJobManager
    {
        Task<string> EnqueueAsync<TJob, TArgs>(TArgs args) where TJob : IBackgroundJob<TArgs>;

        Task<string> ScheduleAsync<TJob, TArgs>(TArgs args, TimeSpan delay) where TJob : IBackgroundJob<TArgs>;

        Task<string> RecurAsync<TJob, TArgs>(TArgs args, string jobId, string cronExpression) where TJob : IBackgroundJob<TArgs>;

        Task<bool> DeleteAsync(string jobId);
    }
}
