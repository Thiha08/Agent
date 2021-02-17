using Agent.Core.BackgroundJobs;
using Hangfire;
using Hangfire.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agent.Hangfire
{
    public class HangfireBackgroundJobManager : IBackgroundJobManager
    {
        public Task<string> EnqueueAsync<TJob, TArgs>(TArgs args) where TJob : IBackgroundJob<TArgs>
        {
            string jobId = BackgroundJob.Enqueue<TJob>(job => job.ExecuteAsync(args));

            return Task.FromResult(jobId);
        }

        public Task<string> ScheduleAsync<TJob, TArgs>(TArgs args, TimeSpan delay) where TJob : IBackgroundJob<TArgs>
        {
            string jobId = BackgroundJob.Schedule<TJob>(job => job.ExecuteAsync(args), delay);

            return Task.FromResult(jobId);
        }

        public Task<string> RecurAsync<TJob, TArgs>(TArgs args, string jobId, string cronExpression) where TJob : IBackgroundJob<TArgs>
        {
            RecurringJob.AddOrUpdate<TJob>(jobId, job => job.ExecuteAsync(args), cronExpression);

            return Task.FromResult(jobId);
        }

        public async Task<bool> DeleteAsync(string jobId)
        {
            if (string.IsNullOrWhiteSpace(jobId))
            {
                throw new ArgumentNullException(nameof(jobId));
            }

            bool successfulDeletion = true;

            var isRecurringJob = await IsRecurringJob(jobId);

            if (isRecurringJob)
                RecurringJob.RemoveIfExists(jobId);
            else
                successfulDeletion = BackgroundJob.Delete(jobId);

            return successfulDeletion;
        }

        private Task<bool> IsRecurringJob(string jobId)
        {
            List<RecurringJobDto> recurringJobs = new List<RecurringJobDto>();
            recurringJobs = JobStorage.Current.GetConnection().GetRecurringJobs().ToList();

            bool isRunning = recurringJobs.Any(x => x.Id == jobId);
            return Task.FromResult(isRunning);
        }
    }
}
