using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC
{
    public class TaskService
    {
        public void Every2MinutesTask(Guid taskId)
        {
            Console.WriteLine($"Every 2 Minutes Task executed at: {DateTime.Now}, Task ID: {taskId}");
        }

        public void Every3MinutesTask(Guid taskId)
        {
            Console.WriteLine($"Every 3 Minutes Task executed at: {DateTime.Now}, Task ID: {taskId}");
        }

        public void Every5MinutesTask(Guid taskId)
        {
            Console.WriteLine($"Every 5 Minutes Task executed at: {DateTime.Now}, Task ID: {taskId}");
        }

        public void EveryHourTask(Guid taskId)
        {
            Console.WriteLine($"Every Hour Task executed at: {DateTime.Now}, Task ID: {taskId}");
        }

        public void EveryMondayAt8AMTask(Guid taskId)
        {
            Console.WriteLine($"Every Monday at 8 AM Task executed at:{DateTime.Now}, Task ID: {taskId}");
        }

        public void FirstOfTheMonthAt8AMTask(Guid taskId)
        {
            Console.WriteLine($"First of the Month at 8 AM Task executed at: {DateTime.Now}, Task ID: {taskId}");
        }
        // Define other tasks similarly...
    }

}
