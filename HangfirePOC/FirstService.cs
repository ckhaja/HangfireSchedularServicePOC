using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC
{
    public class FirstService
    {
        public void FirstOfMonthTask(Guid taskId)
        {
            Console.WriteLine($"FirstService - First of Month Task executed at: {DateTime.Now}, Task ID: {taskId}");
        }
    }
}
