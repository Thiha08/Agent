using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Core.BackgroundJobs
{
    public abstract class BackgroundJob<TArgs> : IBackgroundJob<TArgs>
    {
        public abstract Task ExecuteAsync(TArgs args);
    }
}
