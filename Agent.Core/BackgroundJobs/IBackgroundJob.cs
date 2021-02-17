using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Core.BackgroundJobs
{
    public interface IBackgroundJob<in TArgs>
    {
        Task ExecuteAsync(TArgs args);
    }
}
