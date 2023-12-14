using Hangfire;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC
{
    public class SchedulerService
    {
        //private readonly IRecurringJobManager _recurringJobManager;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly SecondService _secondService;

        //public SchedulerService(IRecurringJobManager recurringJobManager, SecondService secondService)
        //{
        //    _recurringJobManager = recurringJobManager;
        //    _secondService = secondService;
        //}
        public SchedulerService(IBackgroundJobClient backgroundJobClient, SecondService secondService)
        {
            _backgroundJobClient = backgroundJobClient;
            _secondService = secondService;
        }

        public void PreCheckTask(Guid taskId)
        {
            if (ShouldReschedule())
            {
                // Reschedule for a later time
                //_recurringJobManager.AddOrUpdate(
                //   "SecondServiceFirstOfMonthTask",
                //   () => _secondService.FirstOfMonthTask(taskId),
                //   "*/30 * * * *");

                // One Time Job Scheduled as needed
                _backgroundJobClient.Schedule(
                    () => _secondService.FirstOfMonthTask(taskId),
                    TimeSpan.FromMinutes(5));
            }
            else
            {
                // Execute the task immediately or as per the original schedule
                _secondService.FirstOfMonthTask(taskId);
            }
        }

        private bool ShouldReschedule()
        {
            // Logic to determine if rescheduling is necessary
            var random = new Random();
            var randomBool = random.Next(2) == 1;
           //return randomBool; // Replace with actual condition
           return true;
        }
    }

}
